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

	[HttpGet("{userId}/GetUserName")]
	public async Task<IActionResult> GetUserName(string userId)
	{
		string userName = await _serviceManager.AuthenticateService.GetUserNameAsync(userId);
		return Ok(userName);
	}

	[HttpPost("register")]
	public async Task RegisterResponse(
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
	public async Task<IActionResult> Login(LogingDto logingDto, CancellationToken cancellationToken = default)
	{
		LoginResponse result = await _serviceManager.AuthenticateService.LoginAsync(logingDto, cancellationToken);
		if (!result.IsAuthSuccessful)
			return Unauthorized(new { message = result.Message });
		return Ok(result);
	}

	[HttpGet("ResendEmail/{id:guid}")]
	public async Task<IActionResult> ResendEmail(string email)
	{
		ArgumentNullException.ThrowIfNull(email, nameof(email));
		await _serviceManager.AuthenticateService.RegisterEmailAsync(email);
		return Ok();
	}

	[HttpPost("ForgotPassword")]
	public async Task<IActionResult> ForgotPassword(string email)
	{
		await _serviceManager.AuthenticateService.ForgotPasswordAsync(email);
		return Ok();
	}

	[HttpPost("ResetPassword")]
	public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto, [FromQuery] string passwordToken, [FromQuery] string id,
		CancellationToken cancellationToken)
	{
		await _serviceManager.AuthenticateService.ResetPasswordAsync(resetPasswordDto, passwordToken, id, cancellationToken);
		return Ok();
	}

	[HttpPost("ChangePassword")]
	[Authorize]
	public async Task<IActionResult> ChangePassword(changePasswordDto changePasswordDto,
		CancellationToken cancellationToken)
	{
		await _serviceManager.AuthenticateService.ChangePasswordAsync(changePasswordDto, cancellationToken);
		return Ok();
	}

	// Logout
	[HttpPost("Logout")]
	[Authorize]
	public async Task<IActionResult> Logout()
	{
		await _serviceManager.AuthenticateService.LogoutAsync();
		return Ok();
	}
}