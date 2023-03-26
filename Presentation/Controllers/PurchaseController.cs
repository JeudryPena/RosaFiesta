using System.Security.Claims;
using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract;
using Contracts.Model.Product.UserInteract.Response;
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
    
    [HttpGet("{userId}/orders")]
    public async Task<IActionResult> GetOrders(CancellationToken cancellationToken)
    {
        IEnumerable<OrderResponse> bills = await _serviceManager.OrderService.GetAllAsync(cancellationToken);
        return Ok(bills);
    }
    
    [HttpGet("{billId}")]
    public async Task<IActionResult> GetOrderById(int billId, CancellationToken cancellationToken)
    {
        OrderResponse bill = await _serviceManager.OrderService.GetByIdAsync(billId, cancellationToken);
        return Ok(bill);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetPurchaseDetails(CancellationToken cancellationToken)
    {
        IEnumerable<PurchaseDetailResponse> purchaseDetails = await _serviceManager.PurchaseDetailService.GetAllAsync(cancellationToken);
        return Ok(purchaseDetails);
    }
    
    [HttpPost("{userId}/purchase/{purchaseNumber}/Discount/{discountCode}/ApplyDiscount")]
    public async Task<IActionResult> ApplyDiscountAsync(int purchaseNumber, string userId,
        string discountCode, CancellationToken cancellationToken)
    {
        ValidDiscountResponse cart = await _serviceManager.OrderService.ApplyDiscountAsync(purchaseNumber, userId, discountCode, cancellationToken);
        return Ok(cart);
    }
    
    [HttpPut("{userId}/purchase/{purchaseNumber}/Discount/{discountCode}/UpdateDiscount")]
    public async Task<IActionResult> UpdateDiscountAsync(string userId, int purchaseNumber, string discountCode, CancellationToken cancellationToken)
    {
        ValidDiscountResponse cart = await _serviceManager.OrderService.UpdateDiscountAsync(userId, purchaseNumber, discountCode, cancellationToken);
        return Ok(cart);
    }
    
    [HttpPost("{userId}/purchase/{purchaseNumber}")]
    public async Task<IActionResult> RemoveDiscountAsync(int purchaseNumber, CancellationToken cancellationToken)
    {
        await _serviceManager.OrderService.RemoveDiscountAsync(purchaseNumber, cancellationToken);
        return Ok();
    }

    [HttpPost("{userId}/payMethod/{payMethodId:guid}/Purchase")]
    public async Task<IActionResult> OrderPurchaseAsync(string userId, Guid payMethodId, [FromBody] OrderDto orderDto, CancellationToken cancellationToken)
    {
        OrderResponse cart = await _serviceManager.OrderService.OrderPurchaseAsync(userId, payMethodId, orderDto, cancellationToken);
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