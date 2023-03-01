using Contracts.Model;
using Contracts.Response;
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
        IEnumerable<UserDto> users = await _serviceManager.UserService.GetAllUserAsync(
            cancellationToken
        );

        return Ok(users);
    }

    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> GetUserById(Guid userId, CancellationToken cancellationToken)
    {
        UserDto userDto = await _serviceManager.UserService.GetUserByIdAsync(
            userId,
            cancellationToken
        );

        return Ok(userDto);
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
}
