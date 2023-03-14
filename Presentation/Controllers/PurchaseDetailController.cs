using System.Security.Claims;
using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PurchaseDetailController: ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public PurchaseDetailController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetPurchaseDetails(CancellationToken cancellationToken)
    {
        PurchaseDetailResponse purchaseDetails = await _serviceManager.PurchaseDetailService.GetAllAsync(cancellationToken);
        return Ok(purchaseDetails);
    }
    
    [HttpGet("{detailId}")]
    public async Task<IActionResult> GetPurchaseDetailById(int detailId, CancellationToken cancellationToken)
    {
        PurchaseDetailResponse purchaseDetail = await _serviceManager.PurchaseDetailService.GetByIdAsync(detailId, cancellationToken);
        return Ok(purchaseDetail);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePurchaseDetail([FromBody] PurchaseDetailDto purchaseDetail, CancellationToken cancellationToken)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        PurchaseDetailResponse purchaseDetailEntity = await _serviceManager.PurchaseDetailService.CreateAsync(purchaseDetail, userId, cancellationToken);
        return Ok(purchaseDetailEntity);
    }
    
    [HttpPut("{detailId}")]
    public async Task<IActionResult> UpdatePurchaseDetail(int detailId, [FromBody] PurchaseDetailDto purchaseDetail, CancellationToken cancellationToken)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        PurchaseDetailResponse purchaseDetailEntity = await _serviceManager.PurchaseDetailService.UpdateAsync(detailId, purchaseDetail, userId, cancellationToken);
        return Ok(purchaseDetailEntity);
    }

    [HttpDelete("{detailId}")]
    public async Task<IActionResult> DeletePurchaseDetail(int detailId, CancellationToken cancellationToken)
    {
        await _serviceManager.PurchaseDetailService.DeleteAsync(detailId,  cancellationToken);
        return Ok();
    }
}