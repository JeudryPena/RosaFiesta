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
    
    [HttpPost]
    public async Task<RegisterResponse> RegisterResponse(PreRegisterDto preRegisterDto, CancellationToken cancellationToken)
    {
        var response = await _serviceManager.UserService.RegisterAsync(preRegisterDto, cancellationToken);
        return response;
    }
}
