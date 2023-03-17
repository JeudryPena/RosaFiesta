using Contracts.Model;
using Contracts.Model.Security;
using Contracts.Model.Security.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public UserController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
    {
        IEnumerable<UsersResponse> users = await _serviceManager.UserService.GetAllUserAsync(
            cancellationToken
        );

        return Ok(users);
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
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateUser(
        [FromBody] UserForCreationDto userForCreationDto,
        CancellationToken cancellationToken
    )
    {
        string? username = User.Identity?.Name;
        UsersResponse user = await _serviceManager.UserService.CreateAsync(
            userForCreationDto,
            username,
            cancellationToken
        );

        return Ok(user);
    }
    
    [HttpGet("{userId}/unlock")]
    [Authorize]
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
    [Authorize]
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
