using Contracts.Model;
using Contracts.Model.Security;
using Contracts.Model.Security.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TokenController: ControllerBase
{
    private readonly IAuthenticateService _authenticateService;
    
    public TokenController( IAuthenticateService authenticateService)
    {
        _authenticateService = authenticateService ?? throw new ArgumentNullException(nameof(authenticateService));
    }
    
    [HttpPost]
    [Route("refresh")]
    public IActionResult Refresh(TokenApiDto? tokenApiDto)
    {
        if (tokenApiDto is null)
            return BadRequest("Invalid client request");
        
        LoginResponse response = _authenticateService.RefreshToken(tokenApiDto);
        return Ok(response);
    }
    
    [HttpPost]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("revoke")]
    public IActionResult Revoke()
    {
        if (User.Identity?.Name != null)
        {
            string username = User.Identity.Name;
            _authenticateService.RevokeToken(username);
        }
        
        return NoContent();
    }
}