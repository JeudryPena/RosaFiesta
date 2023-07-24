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

	[HttpGet("rolesList")]
	public async Task<IActionResult> RolesList(CancellationToken cancellationToken)
	{
		IEnumerable<RolesListResponse> roles = await _serviceManager.UserService.GetRolesListAsync(
							cancellationToken);
		return Ok(roles);
	}

	[HttpGet("listaUsuarios")]
	public async Task<IActionResult> ListaUsuarios(CancellationToken cancellationToken)
	{
		IEnumerable<UsersListResponse> users = await _serviceManager.UserService.GetUsersListAsync(
					cancellationToken
							);
		return Ok(users);
	}


	[HttpGet]
	public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
	{
		IEnumerable<ManagementUsersResponse> users = await _serviceManager.UserService.GetAllUserAsync(
			cancellationToken
		);

		return Ok(users);
	}


	[HttpGet("{userId}")]
	public async Task<IActionResult> RetrieveById(string userId, CancellationToken cancellationToken)
	{
		UserResponse usersResponse = await _serviceManager.UserService.GetUserByIdAsync(
			userId,
			cancellationToken
		);

		return Ok(usersResponse);
	}

	[HttpPost]
	public async Task<IActionResult> Persist(
		[FromBody] UserForCreationDto userForCreationDto,
		CancellationToken cancellationToken
	)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.UserService.CreateAsync(
			userForCreationDto,
			userId,
			cancellationToken
		);

		return Ok();
	}

	[HttpGet("{userId}/unlock")]
	public async Task<IActionResult> UnlockUser(string userId, CancellationToken cancellationToken)
	{
		string? unlockerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.UserService.UnlockUserAsync(
			userId,
			unlockerId,
			cancellationToken
		);

		return Ok();
	}

	[HttpGet("{userId}/lock")]
	public async Task<IActionResult> LockUser(string userId, CancellationToken cancellationToken)
	{
		string? unlockerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.UserService.LockUserAsync(
			userId,
			unlockerId,
			cancellationToken
		);

		return Ok();
	}

	[HttpPut("{userId}")]
	public async Task<IActionResult> UpdateUser(
		string userId,
		[FromBody] UserForCreationDto userForUpdateDto,
		CancellationToken cancellationToken
	)
	{
		string? updaterId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.UserService.UpdateAsync(
			updaterId,
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
