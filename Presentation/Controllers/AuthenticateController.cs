using System.Net;
using System.Security.Claims;

using Contracts.Model.Security;
using Contracts.Model.Security.Response;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticateController : ControllerBase
{
	private readonly IServiceManager _serviceManager;
	private readonly IConfiguration _goolgeSettings;

	public AuthenticateController(IServiceManager serviceManager, IConfiguration goolgeSettings)
	{
		_serviceManager = serviceManager;
		_goolgeSettings = goolgeSettings;
	}
	
	[HttpGet("change-promotional-emails")]
	public async Task<IActionResult> ChangePromotionalEmailsAsync(CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			throw new Exception("User not found");
		await _serviceManager.UserService.ChangePromotionalEmailsAsync(userId, cancellationToken);
		return Ok();
	}
	
	[HttpGet("delete-user")]
	public async Task<IActionResult> DeleteMyUserAsync(CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			throw new Exception("User not found");
		await _serviceManager.UserService.DeleteMyUserAsync(userId, cancellationToken);
		return Ok();
	}

	[HttpGet("currentUser")]
	[Authorize]
	public async Task<IActionResult> CurrentUser(CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			throw new Exception("User not found");
		string userName = await _serviceManager.UserService.GetUserName(userId, cancellationToken);
		return Ok(new { UserName = userName });
	}
	
	[HttpGet("get-current-user")]
	[Authorize]
	public async Task<IActionResult> RetrieveCurrent(CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		UserResponse usersResponse = await _serviceManager.UserService.GetUserByIdAsync(
			userId,
			cancellationToken
		);

		return Ok(usersResponse);
	}

	[HttpPost("register")]
	public async Task RegisterAsync(
		RegisterDto registerDto,
		CancellationToken cancellationToken
	)
	{
		await _serviceManager.AuthenticateService.RegisterAsync(
			 registerDto,
			 cancellationToken
		 );
	}

	[HttpPost("login")]
	public async Task<IActionResult> LoginAsync(LogingDto logingDto, CancellationToken cancellationToken = default)
	{
		LoginResponse result = await _serviceManager.AuthenticateService.LoginAsync(logingDto, cancellationToken);
		if (!result.IsAuthSuccessful)
			return Unauthorized(new { message = result.Message });
		return Ok(result);
	}


	[HttpPost("external")]
	public async Task<IActionResult> ExternalLogin([FromBody] ExternalAuthDto externalAuth)
	{
		var client = _goolgeSettings["GoogleAuthSettings:clientId"];
		if (client == null)
			throw new ArgumentNullException(nameof(client));
		LoginResponse response = await _serviceManager.AuthenticateService.VerifyGoogle(externalAuth, client);
		if (!response.IsAuthSuccessful)
			return Unauthorized(new { message = response.Message });
		return Ok(response);
	}

	[HttpGet("confirm-email")]
	public async Task ConfirmEmailAsync([FromQuery] string token, [FromQuery] string email,
		CancellationToken cancellationToken)
	{
		await _serviceManager.AuthenticateService.ConfirmEmailAsync(token, email, cancellationToken);
	}

	[HttpGet("resendEmail")]
	public async Task<IActionResult> ResendEmailAsync(string email)
	{
		ArgumentNullException.ThrowIfNull(email, nameof(email));
		await _serviceManager.AuthenticateService.ResendEmail(email);
		return Ok();
	}

	[HttpGet("forgot-password/{email}")]
	public async Task<IActionResult> ForgotPasswordAsync(string email)
	{
		await _serviceManager.AuthenticateService.ForgotPasswordAsync(email);
		return Ok();
	}

	[HttpPost("reset-password")]
	public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordDto resetPasswordDto, [FromQuery] string token, [FromQuery] string email,
		CancellationToken cancellationToken)
	{
		await _serviceManager.AuthenticateService.ResetPasswordAsync(resetPasswordDto, token, email, cancellationToken);
		return Ok();
	}

	[HttpPost("change-password")]
	[Authorize]
	public async Task<IActionResult> ChangePasswordAsync(changePasswordDto changePasswordDto,
		CancellationToken cancellationToken)
	{
		await _serviceManager.AuthenticateService.ChangePasswordAsync(changePasswordDto, cancellationToken);
		return Ok();
	}

	[HttpPost("logout")]
	[Authorize]
	public async Task<IActionResult> LogoutAsync()
	{
		await _serviceManager.AuthenticateService.LogoutAsync();
		return Ok();
	}
}