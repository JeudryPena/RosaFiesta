using System.Net;
using System.Security.Claims;

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
public class PurchaseController : ControllerBase
{
	private readonly IServiceManager _serviceManager;

	public PurchaseController(IServiceManager serviceManager)
	{
		_serviceManager = serviceManager;
	}

	[HttpGet("orders")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> RetrieveAll(CancellationToken cancellationToken)
	{
		IEnumerable<OrderPreviewResponse> orders = await _serviceManager.OrderService.GetAllAsync(cancellationToken);
		return Ok(orders);
	}

	[HttpGet("orders/{userId}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> RetrieveUserOrders(string userId, CancellationToken cancellationToken)
	{
		IEnumerable<OrderPreviewResponse> orders = await _serviceManager.OrderService.GetByUserIdAsync(userId, cancellationToken);
		return Ok(orders);
	}

	[HttpGet("myOrders")]
	public async Task<IActionResult> RetrieveMyOrders(CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		IEnumerable<OrderPreviewResponse> bills = await _serviceManager.OrderService.GetByUserIdAsync(userId, cancellationToken);
		return Ok(bills);
	}

	[HttpGet("{orderId:guid}")]
	public async Task<IActionResult> RetrieveById(Guid orderId, CancellationToken cancellationToken)
	{
		OrderResponse bill = await _serviceManager.OrderService.GetByIdAsync(orderId, cancellationToken);
		return Ok(bill);
	}

	[HttpGet]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> RetrieveDetails(CancellationToken cancellationToken)
	{
		IEnumerable<PurchaseDetailResponse> purchaseDetails = await _serviceManager.PurchaseDetailService.GetAllAsync(cancellationToken);
		return Ok(purchaseDetails);
	}

	[HttpGet("{detailId:guid}")]
	public async Task<IActionResult> RetrieveDetailById(Guid detailId, CancellationToken cancellationToken)
	{
		PurchaseDetailResponse purchaseDetail = await _serviceManager.PurchaseDetailService.GetByIdAsync(detailId, cancellationToken);
		return Ok(purchaseDetail);
	}

	[HttpGet("address/{addressId:guid}/purchase")]
	public async Task<IActionResult> Purchase(CancellationToken cancellationToken, Guid addressId)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		OrderResponse cart = await _serviceManager.OrderService.OrderPurchaseAsync(userId, addressId, cancellationToken);
		return Ok(cart);
	}

	[HttpPut("{detailId:guid}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> UpdatePurchaseDetail(Guid detailId, [FromBody] PurchaseDetailDto purchaseDetail, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		PurchaseDetailResponse purchaseDetailEntity = await _serviceManager.PurchaseDetailService.UpdateAsync(userId, detailId, purchaseDetail, cancellationToken);
		return Ok(purchaseDetailEntity);
	}

	[HttpGet("{orderId:guid}/purchases/{detailId:guid}/return")]
	public async Task<IActionResult> ReturnOrder(Guid orderId, Guid detailId, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.OrderService.ReturnOrderDetailAsync(userId, orderId, detailId, cancellationToken);
		return Ok();
	}

	[HttpDelete("{detailId}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> DeletePurchaseDetail(Guid detailId, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.PurchaseDetailService.DeleteAsync(userId, detailId, cancellationToken);
		return Ok();
	}
}