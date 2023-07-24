using Contracts.Model.Security;
using Contracts.Model.Security.Response;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticateController : ControllerBase
{
	private readonly IServiceManager _serviceManager;

	public AuthenticateController(IServiceManager serviceManager)
	{
		_serviceManager = serviceManager;
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