using System.Net;
using System.Security.Claims;
using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract;
using Contracts.Model.Product.UserInteract.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PurchaseController: ControllerBase
{
    private readonly IServiceManager _serviceManager;
    
    public PurchaseController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    [HttpGet("orders")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetOrders(CancellationToken cancellationToken)
    {
        IEnumerable<OrderResponse> bills = await _serviceManager.OrderService.GetAllAsync(cancellationToken);
        return Ok(bills);
    }
    
    [HttpGet("myOrders")]
    public async Task<IActionResult> GetMyOrders(CancellationToken cancellationToken)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        IEnumerable<OrderResponse> bills = await _serviceManager.OrderService.GetByUserIdAsync(userId, cancellationToken);
        return Ok(bills);
    }
    
    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetOrderById(int orderId, CancellationToken cancellationToken)
    {
        OrderResponse bill = await _serviceManager.OrderService.GetByIdAsync(orderId, cancellationToken);
        return Ok(bill);
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetPurchaseDetails(CancellationToken cancellationToken)
    {
        IEnumerable<PurchaseDetailResponse> purchaseDetails = await _serviceManager.PurchaseDetailService.GetAllAsync(cancellationToken);
        return Ok(purchaseDetails);
    }

    [HttpPut("purchase/{purchaseNumber}/discount/{discountCode}/SelectDiscount")]
    public async Task<IActionResult> SelectDiscountAsync(int purchaseNumber, string discountCode, CancellationToken cancellationToken)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        ValidDiscountResponse cart = await _serviceManager.OrderService.SelectDiscountAsync(userId, purchaseNumber, discountCode, cancellationToken);
        return Ok(cart);
    }
    
    [HttpPost("purchase/{purchaseNumber}")]
    public async Task<IActionResult> RemoveDiscountAsync(int purchaseNumber, CancellationToken cancellationToken)
    {
        await _serviceManager.OrderService.RemoveDiscountAsync(purchaseNumber, cancellationToken);
        return Ok();
    }

    [HttpPost("payMethod/{payMethodId:guid}/Purchase")]
    public async Task<IActionResult> OrderPurchaseAsync(Guid payMethodId, [FromBody] OrderDto orderDto, CancellationToken cancellationToken)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
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
        PurchaseDetailResponse purchaseDetailEntity = await _serviceManager.PurchaseDetailService.UpdateAsync(detailId, purchaseDetail, cancellationToken);
        return Ok(purchaseDetailEntity);
    }

    [HttpDelete("{detailId}")]
    public async Task<IActionResult> DeletePurchaseDetail(int detailId, CancellationToken cancellationToken)
    {
        await _serviceManager.PurchaseDetailService.DeleteAsync(detailId,  cancellationToken);
        return Ok();
    }
}