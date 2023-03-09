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
    [Authorize]
    public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
    {
        IEnumerable<UsersResponse> users = await _serviceManager.UserService.GetAllUserAsync(
            cancellationToken
        );

        return Ok(users);
    }

    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> GetUserById(Guid userId, CancellationToken cancellationToken)
    {
        UsersResponse usersResponse = await _serviceManager.UserService.GetUserByIdAsync(
            userId,
            cancellationToken
        );

        return Ok(usersResponse);
    }

    
    
    [HttpPut("{userId:guid}")]
    public async Task<IActionResult> UpdateUser(
        Guid userId,
        [FromBody] UserForUpdateDto userForUpdateDto,
        CancellationToken cancellationToken
    )
    {
        await _serviceManager.UserService.UpdateAsync(
            userId,
            userForUpdateDto,
            cancellationToken
        );
        return NoContent();
    }
    
    [HttpDelete("{userId:guid}")]
    public async Task<IActionResult> DeleteUser(Guid userId, CancellationToken cancellationToken)
    {
        await _serviceManager.UserService.DeleteAsync(
            userId,
            cancellationToken
        );
        return NoContent();
    }
}
