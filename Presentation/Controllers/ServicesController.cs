using System.Net;
using System.Security.Claims;
using Contracts.Model.Enterprise;
using Contracts.Model.Enterprise.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicesController: ControllerBase
{
     private readonly IServiceManager _serviceManager;
     
     public ServicesController(IServiceManager serviceManager)
     {
         _serviceManager = serviceManager;
     }
     
     [HttpGet("services")]
    public async Task<IActionResult> GetServices(CancellationToken cancellationToken)
    {
        IEnumerable<ServiceResponse> options = await _serviceManager.ServiceService.GetAllAsync(cancellationToken);
        return Ok(options);
    }
    
    [HttpGet("{serviceId:guid}/option")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetServiceById(Guid serviceId, CancellationToken cancellationToken)
    {
        ServiceResponse service = await _serviceManager.ServiceService.GetServiceAsync(serviceId, cancellationToken);
        return Ok(service);
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateService([FromBody] ServiceDto serviceDto, CancellationToken cancellationToken)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        ServiceResponse service = await _serviceManager.ServiceService.CreateAsync(userId, serviceDto, cancellationToken);
        return Ok(service);
    }

    [HttpPut("{serviceId:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateService([FromBody] ServiceUpdateDto serviceDto, CancellationToken cancellationToken, Guid serviceId)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        ServiceResponse service = await _serviceManager.ServiceService.UpdateAsync(userId, serviceId, serviceDto, cancellationToken);
        return Ok(service);
    }
    

    [HttpPut("{serviceId:guid}/adjustQuantity")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AdjustServiceQuantity(int count, CancellationToken cancellationToken, Guid serviceId)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        ServiceResponse service = await _serviceManager.ServiceService.AdjustOptionQuantityAsync(userId, serviceId, count, cancellationToken);
        return Ok(service);
    }
    
    [HttpDelete("{serviceId:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteService(CancellationToken cancellationToken, Guid serviceId)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        await _serviceManager.ServiceService.DeleteAsync(userId, serviceId, cancellationToken);
        return Ok();
    }
}