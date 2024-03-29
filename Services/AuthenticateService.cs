﻿using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web;

using Contracts.Model.Security;
using Contracts.Model.Security.Response;

using Domain.Entities.Product.UserInteract;
using Domain.Entities.Security;
using Domain.Exceptions;
using Domain.IRepository;

using Google.Apis.Auth;

using Mapster;

using Messaging;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using Services.Abstractions;

namespace Services;

internal sealed class AuthenticateService : IAuthenticateService
{
	private readonly UserManager<UserEntity> _userManager;
	private readonly IEmailSender _emailSender;
	private readonly IHttpContextAccessor _httpContext;
	private readonly IConfiguration _configuration;
	private readonly IRepositoryManager _repositoryManager;

	public AuthenticateService(UserManager<UserEntity> userManager, IEmailSender emailSender, IHttpContextAccessor httpContext, IConfiguration configuration, IRepositoryManager repositoryManager)
	{
		_userManager = userManager;
		_emailSender = emailSender;
		_httpContext = httpContext;
		_configuration = configuration;
		_repositoryManager = repositoryManager;
	}

	public async Task RegisterAsync(
		RegisterDto registerDto,
		CancellationToken cancellationToken = default
	)
	{
		await _repositoryManager.UserRepository.VerifyIfUserAlredyExistsAsync(registerDto.UserName, cancellationToken);
		await _repositoryManager.UserRepository.VerifyIfEmailAlredyExistsAsync(registerDto.Email, cancellationToken);
		UserEntity user = registerDto.Adapt<UserEntity>();
		user.Id = Guid.NewGuid().ToString();
		var result = await _userManager.CreateAsync(user, registerDto.Password)
			.ConfigureAwait(false);
		IdentityResultMessage(result);
		result = await _userManager.AddToRoleAsync(user, "Client")
			.ConfigureAwait(false);
		IdentityResultMessage(result);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(null, cancellationToken);
		await ResendEmail(user.Email);
	}

	public async Task ResendEmail(string email)
	{
		var user = await _userManager.FindByEmailAsync(email) ?? throw new InvalidOperationException("User not found");
		var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
		string codeEncoded = HttpUtility.UrlEncode(token);
		var param = new Dictionary<string, string?>
		{
			{"token", codeEncoded },
			{"email", email},
		};

		var callback = QueryHelpers.AddQueryString("http://localhost:4200/auth", param);

		var htmlButton = $"<a href='{callback}' style='background-color: #4CAF50; border: none; color: white; padding: 15px 32px; text-align: center; text-decoration: none; display: inline-block; font-size: 16px;'>Confirmar Usuario</a>";

		var message = new EmailMessage(new[] { email }, "Correo de confirmación de Email", $"Haz click en el siguiente boton para confirmar el registro de tu nuevo Usuario: <br/> <br/> {htmlButton}", null);
		await _emailSender.SendEmailAsync(message);
	}

	public async Task<LoginResponse> VerifyGoogle(ExternalAuthDto externalAuth, string client)
	{
		var payload = await VerifyGoogleToken(externalAuth, client);
		if (payload == null)
			throw new("Invalid External Authentication.");

		var info = new UserLoginInfo(externalAuth.Provider, payload.Subject, externalAuth.Provider);

		var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
		if (user == null)
		{
			user = await _userManager.FindByEmailAsync(payload.Email);

			if (user == null)
			{
				user = new UserEntity
				{
					Email = payload.Email,
					UserName = payload.Email,
					EmailConfirmed = payload.EmailVerified,
					Cart = new CartEntity { Id = Guid.NewGuid() },
					WishList = new WishListEntity { Id = Guid.NewGuid() },
				};
				await _userManager.CreateAsync(user);
				await _userManager.AddToRoleAsync(user, "Client");
				await _userManager.AddLoginAsync(user, info);
			}
			else
				await _userManager.AddLoginAsync(user, info);
		}
		if (user == null)
			throw new("Invalid External Authentication.");
		var token = GenerateAccessToken(user);
		return new LoginResponse { Token = token.Token, IsAuthSuccessful = true };
	}

	public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(ExternalAuthDto externalAuth, string client)
	{
		try
		{
			var settings = new GoogleJsonWebSignature.ValidationSettings()
			{
				Audience = new List<string>() { client }
			};
			var payload = await GoogleJsonWebSignature.ValidateAsync(externalAuth.IdToken, settings);
			return payload;
		}
		catch (Exception ex)
		{
			//log an exception
			return null;
		}
	}

	public async Task ConfirmEmailAsync(string token, string email, CancellationToken cancellationToken = default)
	{
		var user = await _userManager.FindByEmailAsync(email) ?? throw new InvalidOperationException("User not found");

		string codeDecoded = HttpUtility.UrlDecode(token);

		var confirmResult = await _userManager.ConfirmEmailAsync(user, codeDecoded).ConfigureAwait(false);

		if (!confirmResult.Succeeded)
			IdentityResultMessage(confirmResult);

		user.Cart = new CartEntity();
		user.WishList = new WishListEntity();
		await _userManager.UpdateAsync(user).ConfigureAwait(false);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(null, cancellationToken);
	}

	public async Task ForgotPasswordAsync(string email)
	{
		var user = await _userManager.FindByEmailAsync(email).ConfigureAwait(false);
		if (user == null || !await _userManager.IsEmailConfirmedAsync(user).ConfigureAwait(false))
		{
			return;
		}
		var token = await _userManager.GeneratePasswordResetTokenAsync(user).ConfigureAwait(false);
		string codeEncoded = HttpUtility.UrlEncode(token);

		var param = new Dictionary<string, string?>
		{
			{"token", codeEncoded },
			{"email", email },
		};
		var callback = QueryHelpers.AddQueryString("http://localhost:4200/auth/reset-password", param);

		var htmlButton = $"<a href='{callback}' style='background-color: #4CAF50; border: none; color: white; padding: 15px 32px; text-align: center; text-decoration: none; display: inline-block; font-size: 16px;'>Reiniciar Contraseña</a>";

		var message = new EmailMessage(new[] { email }, "Reiniciar Contraseña Rosafiesta", $"Haz click en el siguiente boton para reiniciar tu contraseña: <br/> <br/> {htmlButton}", null);
		await _emailSender.SendEmailAsync(message).ConfigureAwait(false);
	}

	public async Task ResetPasswordAsync(ResetPasswordDto resetPasswordDto, string passwordToken, string email, CancellationToken cancellationToken = default)
	{
		var user = await _userManager.FindByEmailAsync(email).ConfigureAwait(false) ?? throw new UserNotFoundException(email);

		string codeDecoded = HttpUtility.UrlDecode(passwordToken);

		var resetPassResult = await _userManager.ResetPasswordAsync(user, codeDecoded, resetPasswordDto.Password).ConfigureAwait(false);
		if (!resetPassResult.Succeeded)
			IdentityResultMessage(resetPassResult);

		await _userManager.SetLockoutEndDateAsync(user, null).ConfigureAwait(false);

		await _repositoryManager.UnitOfWork.SaveChangesAsync(null, cancellationToken);
	}

	public async Task ChangePasswordAsync(changePasswordDto changePasswordDto, CancellationToken cancellationToken = default)
	{
		var userId = CurrentUserId();
		var user = await _userManager.FindByIdAsync(userId) ?? throw new UserNotFoundException(userId);

		var changePassResult = await _userManager.ChangePasswordAsync(user, changePasswordDto.OldPassword, changePasswordDto.NewPassword);
		if (!changePassResult.Succeeded)
			IdentityResultMessage(changePassResult);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(null, cancellationToken);
	}

	public async Task LogoutAsync()
	{
		var userId = CurrentUserId();
		var user = await _userManager.FindByIdAsync(userId) ?? throw new UserNotFoundException(userId);
		user.RefreshToken = null;
		user.RefreshTokenExpiryTime = null;
		await _userManager.UpdateAsync(user).ConfigureAwait(false);
	}

	public async Task<LoginResponse> LoginAsync(LogingDto logingDto, CancellationToken cancellationToken = default)
	{
		var user = await _userManager.FindByNameAsync(logingDto.Username).ConfigureAwait(false);
		if (user == null)
		{
			user = await _userManager.FindByEmailAsync(logingDto.Username).ConfigureAwait(false);
		}
		if (user == null)
		{
			return new LoginResponse { Message = "Usuario o contraseña incorrecta" };
		}
		var result = await _userManager.CheckPasswordAsync(user, logingDto.Password);
		if (!result)
		{
			await _userManager.AccessFailedAsync(user);
			return new LoginResponse { Message = "Usuario o contraseña incorrecta" };
		}
		if (!await _userManager.IsEmailConfirmedAsync(user))
		{
			return new LoginResponse { Message = "Correo no confirmado" };
		}

		if (result)
		{
			var accessToken = GenerateAccessToken(user);
			var refreshToken = GenerateRefreshToken();

			user.RefreshToken = refreshToken;
			user.RefreshTokenExpiryTime = DateTimeOffset.UtcNow.AddDays(7);

			await _userManager.SetLockoutEndDateAsync(user, null).ConfigureAwait(false);
			await _userManager.ResetAccessFailedCountAsync(user);
			await _userManager.UpdateAsync(user);
			await _repositoryManager.UnitOfWork.SaveChangesAsync(null, cancellationToken);

			return new LoginResponse
			{
				Token = accessToken.Token,
				Expiration = accessToken.Expiration,
				RefreshToken = refreshToken,
				IsAuthSuccessful = true
			};
		}

		if (await _userManager.GetAccessFailedCountAsync(user) >= 5)
		{
			var token = await _userManager.GeneratePasswordResetTokenAsync(user).ConfigureAwait(false);
			string codeEncoded = HttpUtility.UrlEncode(token);

			var param = new Dictionary<string, string?>
			{
				{"token", codeEncoded },
				{"id", user.Id },
			};

			var callback = QueryHelpers.AddQueryString("http://localhost:4200/auth/unlock-account", param);
			var callback2 = QueryHelpers.AddQueryString("http://localhost:4200/auth/reset-password", param);

			var htmlButton = $"<a href='{callback}' style='background-color: #4CAF50; border: none; color: white; padding: 15px 32px; text-align: center; text-decoration: none; display: inline-block; font-size: 16px;'>Restore User</a>";

			var htmlButton2 = $"<a href='{callback2}' style='background-color: #4CAF50; border: none; color: white; padding: 15px 32px; text-align: center; text-decoration: none; display: inline-block; font-size: 16px;'>Reset Password</a>";

			var content = $"Tu usuario de RosaFiesta, le ha sido bloqueado el acceso para protegerte, debido a que se ha intentado acceder varias veces sin exito. Para desbloquearla haz click en el siguiente link: <br> <br> {htmlButton} <br> <br> o si sientes que debas cambiar tu contraseña para estar mas seguro, haz click en el siguiente enlace: <br> <br> {htmlButton2}";

			var message = new EmailMessage(new[] { logingDto.Username },
				"Usuario bloqueado temporalmente", content, null);

			await _emailSender.SendEmailAsync(message).ConfigureAwait(false);

			return new LoginResponse { Message = "El usuario ha sido bloqueado temporalmente, revisa tu correo" };
		}

		if (await _userManager.IsLockedOutAsync(user))
		{
			return new LoginResponse { Message = "El usuario esta bloqueado temporalmente, revisa tu correo" };
		}
		return new LoginResponse { Message = "Usuario o contraseña invalida" };
	}

	public LoginResponse RefreshToken(TokenApiDto tokenApiDto)
	{
		string accessToken = tokenApiDto.AccessToken ?? throw new InvalidOperationException();
		string refreshToken = tokenApiDto.RefreshToken ?? throw new InvalidOperationException();
		var principal = GetPrincipalFromExpiredToken(accessToken);
		var username = principal.Identity?.Name;
		var user = _userManager.Users.SingleOrDefault(x => x.UserName == username);
		if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTimeOffset.Now)
			throw new SecurityTokenException("Invalid refresh token");
		TokenResponse newAccessToken = GenerateAccessToken(user);
		var newRefreshToken = GenerateRefreshToken();
		user.RefreshToken = newRefreshToken;
		_userManager.UpdateAsync(user);
		return new LoginResponse
		{
			Token = newAccessToken.Token,
			Expiration = newAccessToken.Expiration,
			RefreshToken = newRefreshToken
		};
	}

	public void RevokeToken(string username)
	{
		var user = _userManager.Users.SingleOrDefault(x => x.UserName == username) ?? throw new SecurityTokenException("Invalid username");
		user.RefreshToken = null;
		_userManager.UpdateAsync(user);
	}

	public async Task<string> GetUserNameAsync(string userId)
	{
		var user = await _userManager.FindByIdAsync(userId) ?? throw new UserNotFoundException(userId);
		return user.UserName!;
	}

	public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
	{
		var tokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345")),
		};
		var tokenHandler = new JwtSecurityTokenHandler();
		SecurityToken securityToken;
		var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
		var jwtSecurityToken = securityToken as JwtSecurityToken;
		if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.OrdinalIgnoreCase))
			throw new SecurityTokenException("Invalid token");
		return principal;
	}

	private TokenResponse GenerateAccessToken(UserEntity user)
	{
		var userRole = _userManager.GetRolesAsync(user).Result;
		var tokenHandler = new JwtSecurityTokenHandler();
		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
			_configuration["JWT:Secret"] ?? throw new InvalidOperationException()));
		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(new Claim[]
			{
				new (ClaimTypes.NameIdentifier, user.Id),
				new (ClaimTypes.Name, user.UserName ?? string.Empty),
				new (ClaimTypes.Role, userRole.FirstOrDefault() ?? string.Empty),
				new (JwtRegisteredClaimNames.Iss, _configuration["JWT:ValidIssuer"] ?? throw new InvalidOperationException()),
				new (JwtRegisteredClaimNames.Aud, _configuration["JWT:ValidAudience"] ?? throw new InvalidOperationException()),
			}),
			Issuer = _configuration["Issuer"],
			Audience = _configuration["Audience"],
			Expires = DateTime.UtcNow.AddHours(8),
			SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
		};

		var token = tokenHandler.CreateToken(tokenDescriptor);
		var tokenResponse = new TokenResponse()
		{
			Token = tokenHandler.WriteToken(token),
			Expiration = token.ValidTo.ToString(CultureInfo.InvariantCulture),
		};

		return tokenResponse;
	}

	public string GenerateRefreshToken()
	{
		var randomNumber = new byte[32];
		using (var rng = RandomNumberGenerator.Create())
		{
			rng.GetBytes(randomNumber);
			return Convert.ToBase64String(randomNumber);
		}
	}

	private void IdentityResultMessage(IdentityResult result)
	{
		if (!result.Succeeded)
		{
			var errors = result.Errors.Select(e => e.Description);
			throw new InvalidOperationException(string.Join(", ", errors));
		}
	}

	public string CurrentUserId()
	{
		var findFirstValue = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException("User not found");
		return findFirstValue;
	}
}