using System.Net;
using System.Security.Claims;

using Contracts.Model.Security;
using Contracts.Model.Security.Response;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class UsersController : ControllerBase
{
	private readonly IServiceManager _serviceManager;

	public UsersController(IServiceManager serviceManager)
	{
		_serviceManager = serviceManager;
	}

	[HttpGet("roles")]
	public async Task<IActionResult> GetRoles(CancellationToken cancellationToken)
	{
		IEnumerable<RolesResponse> roles = await _serviceManager.UserService.GetAllRolesAsync(
					cancellationToken
							);
		return Ok(roles);
	}

	[HttpGet]
	public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
	{
		IEnumerable<ManagementUsersResponse> users = await _serviceManager.UserService.GetAllUserAsync(
			cancellationToken
		);
		
		return Ok(users);
	}

	[HttpGet("{userId}/user-name")]
	public async Task<IActionResult> GetUserNameById(string userId, CancellationToken cancellationToken)
	{
		string? userName = await _serviceManager.UserService.GetUserNameByIdAsync(userId, cancellationToken);

		return Ok(new { UserName = userName });
	}


	[HttpGet("{userId}")]
	public async Task<IActionResult> GetUserById(string userId, CancellationToken cancellationToken)
	{
		UsersResponse usersResponse = await _serviceManager.UserService.GetUserByIdAsync(
			userId,
			cancellationToken
		);

		return Ok(usersResponse);
	}

	[HttpPost]
	public async Task<IActionResult> CreateUser(
		[FromBody] UserForCreationDto userForCreationDto,
		CancellationToken cancellationToken
	)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		UsersResponse user = await _serviceManager.UserService.CreateAsync(
			userForCreationDto,
			userId,
			cancellationToken
		);

		return Ok(user);
	}

	[HttpGet("{userId}/unlock")]
	public async Task<IActionResult> UnlockUser(string userId, CancellationToken cancellationToken)
	{
		string? username = User.Identity?.Name;
		await _serviceManager.UserService.UnlockUserAsync(
			userId,
			username,
			cancellationToken
		);

		return Ok();
	}

	[HttpGet("{userId}/lock")]
	public async Task<IActionResult> LockUser(string userId, CancellationToken cancellationToken)
	{
		string? username = User.Identity?.Name;
		await _serviceManager.UserService.LockUserAsync(
			userId,
			username,
			cancellationToken
		);

		return Ok();
	}

	[HttpPut("{userId}")]
	public async Task<IActionResult> UpdateUser(
		string userId,
		[FromBody] UserForUpdateDto userForUpdateDto,
		CancellationToken cancellationToken
	)
	{
		string? username = User.Identity?.Name;
		await _serviceManager.UserService.UpdateAsync(
			username,
			userId,
			userForUpdateDto,
			cancellationToken
		);
		return NoContent();
	}

	[HttpDelete("{userId}")]
	public async Task<IActionResult> DeleteUser(string userId, CancellationToken cancellationToken)
	{
		await _serviceManager.UserService.DeleteAsync(
			userId,
			cancellationToken
		);
		return NoContent();
	}
}
