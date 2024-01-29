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
public class PurchaseController : ControllerBase
{
	private readonly IServiceManager _serviceManager;

	public PurchaseController(IServiceManager serviceManager)
	{
		_serviceManager = serviceManager;
	}
	
	[HttpGet("count")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> RetrieveCount(CancellationToken cancellationToken)
	{
		int count = await _serviceManager.PurchaseDetailService.GetCountAsync(cancellationToken);
		return Ok(count);
	}
	
	[HttpGet("gains")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> RetrieveGains(CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		double gains = await _serviceManager.OrderService.GetGainsAsync(cancellationToken);
		return Ok(gains);
	}
	
	[HttpGet("most-purchased-products")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> RetrieveMostPurchasedProductsAsync(CancellationToken cancellationToken)
	{
		IEnumerable<MostPurchasedProductsResponse> mostPurchasedProducts = await _serviceManager.ProductService.GetMostPurchasedProductsAsync(cancellationToken);
		return Ok(mostPurchasedProducts);
	}
	
	[HttpGet("most-purchased-products/{start}/{end}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> RetrieveMostPurchasedProductsWithDatesAsync(DateOnly start, DateOnly end, CancellationToken cancellationToken)
	{
		IEnumerable<MostPurchasedProductsWithDatesResponse> mostPurchasedProducts = await _serviceManager.ProductService.GetMostPurchasedProductsWithDatesAsync(start, end, cancellationToken);
		return Ok(mostPurchasedProducts);
	}

	[HttpGet("orders/{take:int}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> RetrieveAll(int take, CancellationToken cancellationToken)
	{
		int? ordersToTake;
		if(take == 0)
			ordersToTake = null;
		else  
			ordersToTake = take;
		IEnumerable<OrderManagementPreviewResponse> orders = await _serviceManager.OrderService.GetAllAsync(ordersToTake,cancellationToken);
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
	
	[HttpPost("create-order")]
	public async Task<IActionResult> CreateOrder(OrderDto orderDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		OrderResponse order = await _serviceManager.OrderService.CreateOrderAsync(orderDto, userId, cancellationToken);
		return Ok(order);
	}

	[HttpGet("{orderId:guid}/detail")]
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

	[HttpPost("purchase")]
	public async Task<IActionResult> Purchase(OrderDto orderDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		OrderResponse cart = await _serviceManager.OrderService.OrderPurchaseAsync(orderDto, userId,  cancellationToken);
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

	[HttpGet("{orderId:guid}/return")]
	public async Task<IActionResult> ReturnOrder(Guid orderId, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		bool valid = await _serviceManager.OrderService.ReturnOrderDetailAsync(userId, orderId, cancellationToken);
		return Ok(valid);
	}
	
	[HttpGet("{orderId:guid}/oficializeReturn")]
	[Authorize(Roles="Admin")]
	public async Task<IActionResult> OficializeReturnOrder(Guid orderId, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		bool valid = await _serviceManager.OrderService.OficializeReturnOrderDetailAsync(userId, orderId, cancellationToken);
		return Ok(valid);
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