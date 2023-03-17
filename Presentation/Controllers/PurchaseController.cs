using System.Security.Claims;
using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PurchaseController: ControllerBase
{
    private readonly IServiceManager _serviceManager;
    
    public PurchaseController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetPurchaseDetails(CancellationToken cancellationToken)
    {
        IEnumerable<PurchaseDetailResponse> purchaseDetails = await _serviceManager.PurchaseDetailService.GetAllAsync(cancellationToken);
        return Ok(purchaseDetails);
    }
    
    [HttpPost("{userId}/products/{productsId}")]
    public async Task<IActionResult> ApplyDiscountAsync(string userId, string productsId,
        string discountCode, CancellationToken cancellationToken)
    {
        ValidDiscountResponse cart = await _serviceManager.OrderService.ApplyDiscountAsync(userId, productsId, discountCode, cancellationToken);
        return Ok(cart);
    }
    
    [HttpPost("{userId}/discountCode/{discountCode}/payMethod/{payMethodId:guid}")]
    public async Task<IActionResult> OrderPurchaseAsync(string userId, Guid payMethodId, string? discountCode, [FromBody] OrderDto orderDto, CancellationToken cancellationToken)
    {
        OrderResponse cart = await _serviceManager.OrderService.OrderPurchaseAsync(userId, payMethodId, discountCode, orderDto, cancellationToken);
        return Ok(cart);
    }

    [HttpGet("{detailId}")]
    public async Task<IActionResult> GetPurchaseDetailById(int detailId, CancellationToken cancellationToken)
    {
        PurchaseDetailResponse purchaseDetail = await _serviceManager.PurchaseDetailService.GetByIdAsync(detailId, cancellationToken);
        return Ok(purchaseDetail);
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