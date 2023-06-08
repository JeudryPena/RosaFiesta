using System.Globalization;
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

	public async Task<RegisterResponse> RegisterAsync(
		RegisterDto registerDto,
		CancellationToken cancellationToken = default
	)
	{
		UserEntity user = new UserEntity
		{
			UserName = registerDto.UserName,
			Email = registerDto.Email,
			BirthDate = registerDto.BirthDate,
			CreatedAt = DateTimeOffset.UtcNow,
			IsDeleted = false,
		};

		var result = await _userManager.CreateAsync(user, registerDto.Password)
			.ConfigureAwait(false);
		IdentityResultMessage(result);

		result = await _userManager.AddToRoleAsync(user, "User")
			.ConfigureAwait(false);
		IdentityResultMessage(result);

		await RegisterEmailAsync(user.Email);

		return new RegisterResponse
		{
			IsSuccess = true,
			Message = "User created successfully",
			Id = user.Id,
			UserName = user.UserName,
			Email = user.Email,
		};
	}

	public async Task RegisterEmailAsync(string email)
	{
		var user = await _userManager.FindByEmailAsync(email) ?? throw new InvalidOperationException("User not found");

		var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
		string codeEncoded = HttpUtility.UrlEncode(token);
		var param = new Dictionary<string, string?>
		{
			{"token", codeEncoded },
			{"id", user.Id},
		};

		var callback = QueryHelpers.AddQueryString("http://localhost:4200/authenticate/confirm-email", param);

		var htmlButton = $"<a href='{callback}' style='background-color: #4CAF50; border: none; color: white; padding: 15px 32px; text-align: center; text-decoration: none; display: inline-block; font-size: 16px;'>Confirm User</a>";

		var message = new EmailMessage(new[] { user.Email }, "Email Confirmation token", $"Click the next button to confirm your user registration: <br/> <br/> {htmlButton}", null);
		await _emailSender.SendEmailAsync(message);
	}

	public async Task<FinishRegisterResponse> CreatePasswordAsync(FinishRegisterDto finishRegisterDto, string token, string id)
	{
		var user = await _userManager.FindByIdAsync(id).ConfigureAwait(false) ?? throw new UserNotFoundException(id);

		string codeDecoded = HttpUtility.UrlDecode(token);

		var confirmResult = await _userManager.ConfirmEmailAsync(user, codeDecoded).ConfigureAwait(false);

		if (!confirmResult.Succeeded)
			IdentityResultMessage(confirmResult);

		user.FullName = finishRegisterDto.Name + " " + finishRegisterDto.LastName;
		user.Cart = new CartEntity();
		await _userManager.UpdateAsync(user).ConfigureAwait(false);

		return new FinishRegisterResponse
		{
			IsSuccess = true,
			Message = "User created successfully",
			Id = user.Id,
			UserName = user.UserName ?? string.Empty,
			Email = user.Email ?? string.Empty,
			FullName = user.FullName,
		};
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
			{"id", user.Id },
		};
		var callback = QueryHelpers.AddQueryString("http://localhost:4200/authenticate/reset-password", param);

		var htmlButton = $"<a href='{callback}' style='background-color: #4CAF50; border: none; color: white; padding: 15px 32px; text-align: center; text-decoration: none; display: inline-block; font-size: 16px;'>Reset Password</a>";

		var message = new EmailMessage(new[] { user.Email }, "Reset password token", $"Click the next button to reset your password: <br/> <br/> {htmlButton}", null);
		await _emailSender.SendEmailAsync(message).ConfigureAwait(false);
	}

	public async Task ResetPasswordAsync(ResetPasswordDto resetPasswordDto, string passwordToken, string id)
	{
		var user = await _userManager.FindByIdAsync(id).ConfigureAwait(false) ?? throw new UserNotFoundException(id);

		string codeDecoded = HttpUtility.UrlDecode(passwordToken);

		var resetPassResult = await _userManager.ResetPasswordAsync(user, codeDecoded, resetPasswordDto.Password).ConfigureAwait(false);
		if (!resetPassResult.Succeeded)
			IdentityResultMessage(resetPassResult);

		await _userManager.SetLockoutEndDateAsync(user, null).ConfigureAwait(false);
	}

	public async Task ChangePasswordAsync(changePasswordDto changePasswordDto)
	{
		var userId = CurrentUserId();
		var user = await _userManager.FindByIdAsync(userId) ?? throw new UserNotFoundException(userId);

		var changePassResult = await _userManager.ChangePasswordAsync(user, changePasswordDto.OldPassword, changePasswordDto.NewPassword);
		if (!changePassResult.Succeeded)
			IdentityResultMessage(changePassResult);
	}

	public async Task LogoutAsync()
	{
		var userId = CurrentUserId();
		var user = await _userManager.FindByIdAsync(userId) ?? throw new UserNotFoundException(userId);
		user.RefreshToken = null;
		user.RefreshTokenExpiryTime = null;
		await _userManager.UpdateAsync(user).ConfigureAwait(false);
	}

	public async Task<LoginResponse> LoginAsync(LogingDto logingDto)
	{
		var user = await _userManager.FindByEmailAsync(logingDto.Username);
		if (user == null)
		{
			return new LoginResponse { Message = "Invalid username or password" };
		}
		var result = await _userManager.CheckPasswordAsync(user, logingDto.Password);
		if (!result)
		{
			await _userManager.AccessFailedAsync(user);
			return new LoginResponse { Message = "Invalid username or password" };
		}
		if (!await _userManager.IsEmailConfirmedAsync(user))
		{
			return new LoginResponse { Message = "Email is not confirmed" };
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

			return new LoginResponse
			{
				Token = accessToken,
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

			var callback = QueryHelpers.AddQueryString("http://localhost:4200/authenticate/unlock-account", param);
			var callback2 = QueryHelpers.AddQueryString("http://localhost:4200/authenticate/reset-password", param);

			var htmlButton = $"<a href='{callback}' style='background-color: #4CAF50; border: none; color: white; padding: 15px 32px; text-align: center; text-decoration: none; display: inline-block; font-size: 16px;'>Restore User</a>";

			var htmlButton2 = $"<a href='{callback2}' style='background-color: #4CAF50; border: none; color: white; padding: 15px 32px; text-align: center; text-decoration: none; display: inline-block; font-size: 16px;'>Reset Password</a>";

			var content = $"Your account is locked out because of many access failures. To unlock the account click this link: <br> <br> {htmlButton} <br> <br> or you could reset your password in this link: <br> <br> {htmlButton2}";

			var message = new EmailMessage(new[] { logingDto.Username },
				"Locked out account information", content, null);

			await _emailSender.SendEmailAsync(message).ConfigureAwait(false);

			return new LoginResponse { Message = "User account is locked out for 5 minutes" };
		}

		if (await _userManager.IsLockedOutAsync(user))
		{
			return new LoginResponse { Message = "User account is temporally locked out" };
		}
		return new LoginResponse { Message = "Invalid username or password" };
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
		var newAccessToken = GenerateAccessToken(user);
		var newRefreshToken = GenerateRefreshToken();
		user.RefreshToken = newRefreshToken;
		_userManager.UpdateAsync(user);
		return new LoginResponse
		{
			Token = newAccessToken,
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

	private string GenerateAccessToken(UserEntity user)
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
				new ("FullName", user.FullName),
				new (JwtRegisteredClaimNames.Iss, _configuration["JWT:ValidIssuer"] ?? throw new InvalidOperationException()),
				new (JwtRegisteredClaimNames.Aud, _configuration["JWT:ValidAudience"] ?? throw new InvalidOperationException()),
			}),
			Issuer = _configuration["Issuer"],
			Audience = _configuration["Audience"],
			Expires = DateTime.UtcNow.AddHours(4),
			SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
		};

		var token = tokenHandler.CreateToken(tokenDescriptor);
		var expiration = token.ValidTo.ToString(CultureInfo.InvariantCulture);
		var tokenString = tokenHandler.WriteToken(token);

		return tokenString;
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