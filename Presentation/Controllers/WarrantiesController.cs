using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WarrantiesController: ControllerBase
{
    private readonly IServiceManager _serviceManager;
    
    public WarrantiesController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetWarranties(CancellationToken cancellationToken)
    {
        IEnumerable<WarrantyResponse> suppliers = await _serviceManager.WarrantyService.GetAllAsync(cancellationToken);
        return Ok(suppliers);
    }
    
    [HttpGet("{warrantyId:guid}")]
    public async Task<IActionResult> GetWarranty(Guid warrantyId, CancellationToken cancellationToken)
    {
        WarrantyResponse warranty = await _serviceManager.WarrantyService.GetWarrantyAsync(warrantyId, cancellationToken);
        return Ok(warranty);
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateWarranty([FromBody] WarrantyDto warranty, CancellationToken cancellationToken)
    {
        string? username = User.Identity?.Name;
        WarrantyResponse warrantyResponse = await _serviceManager.WarrantyService.CreateWarrantyAsync(username, warranty, cancellationToken);
        return Ok(warrantyResponse);
    }

    [HttpPut("{warrantyId:guid}")]
    [Authorize]
    public async Task<IActionResult> UpdateWarranty(Guid warrantyId,[FromBody] WarrantyDto warrantyDto, CancellationToken cancellationToken)
    {
        string? username = User.Identity?.Name;
        WarrantyResponse warrantyResponse = await _serviceManager.WarrantyService.UpdateWarrantyAsync(username, warrantyId, warrantyDto, cancellationToken);
        return Ok(warrantyResponse);
    }
    
    [HttpDelete("{warrantyId:guid}")]
    public async Task<IActionResult> DeleteWarranty(Guid warrantyId, CancellationToken cancellationToken)
    {
        await _serviceManager.WarrantyService.DeleteWarrantyAsync(warrantyId, cancellationToken);
        return Ok();
    }
}