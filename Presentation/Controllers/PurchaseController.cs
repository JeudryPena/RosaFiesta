using System.Net;
using System.Security.Claims;
using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract;
using Contracts.Model.Product.UserInteract.Response;
using Contracts.Model.Security;
using Contracts.Model.Security.Response;
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
        IEnumerable<OrderPreviewResponse> orders = await _serviceManager.OrderService.GetAllAsync(cancellationToken);
        return Ok(orders);
    }
    
    [HttpGet("myOrders")]
    public async Task<IActionResult> GetMyOrders(CancellationToken cancellationToken)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        IEnumerable<OrderPreviewResponse> bills = await _serviceManager.OrderService.GetByUserIdAsync(userId, cancellationToken);
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
    
    [HttpGet("{detailId}")]
    public async Task<IActionResult> GetPurchaseDetailById(int detailId, CancellationToken cancellationToken)
    {
        PurchaseDetailResponse purchaseDetail = await _serviceManager.PurchaseDetailService.GetByIdAsync(detailId, cancellationToken);
        return Ok(purchaseDetail);
    }
    
    [HttpPost("purchase/{purchaseNumber}")]
    public async Task<IActionResult> RemoveDiscountAsync(int purchaseNumber, CancellationToken cancellationToken)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        await _serviceManager.OrderService.RemoveDiscountAsync(userId, purchaseNumber, cancellationToken);
        return Ok();
    }

    [HttpPost("payMethod/{payMethodId:guid}/Address/{addressId:guid}/Purchase")]
    public async Task<IActionResult> OrderPurchaseAsync(Guid payMethodId, [FromBody]  CancellationToken cancellationToken, Guid addressId)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        OrderResponse cart = await _serviceManager.OrderService.OrderPurchaseAsync(userId, payMethodId, addressId, cancellationToken);
        return Ok(cart);
    }

    [HttpPut("{purchaseNumber}/option{optionId}/discount/{discountCode}/SelectDiscount")]
    public async Task<IActionResult> SelectDiscountAsync(int purchaseNumber, int optionId, string discountCode, CancellationToken cancellationToken)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        ValidDiscountResponse cart = await _serviceManager.OrderService.SelectDiscountAsync(userId, purchaseNumber, discountCode, optionId, cancellationToken);
        return Ok(cart);
    }
    
    [HttpPut("{detailId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdatePurchaseDetail(int detailId, [FromBody] PurchaseDetailDto purchaseDetail, CancellationToken cancellationToken)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        PurchaseDetailResponse purchaseDetailEntity = await _serviceManager.PurchaseDetailService.UpdateAsync(userId, detailId, purchaseDetail, cancellationToken);
        return Ok(purchaseDetailEntity);
    }
    
    [HttpPut("{orderId}/purchases/{purchaseNumber}/return")]
    public async Task<IActionResult> ReturnOrder(int orderId, int purchaseNumber, CancellationToken cancellationToken)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        await _serviceManager.OrderService.ReturnOrderDetailAsync(userId, orderId, purchaseNumber, cancellationToken);
        return Ok();
    }

    [HttpDelete("{detailId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeletePurchaseDetail(int detailId, CancellationToken cancellationToken)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        await _serviceManager.PurchaseDetailService.DeleteAsync(userId, detailId,  cancellationToken);
        return Ok();
    }
}