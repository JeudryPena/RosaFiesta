using System.Net;
using System.Security.Claims;

using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CartsController : ControllerBase
{
	private readonly IServiceManager _serviceManager;

	public CartsController(IServiceManager serviceManager)
	{
		_serviceManager = serviceManager;
	}

	[HttpGet("product/{productId:guid}/option/{optionId}/discountPreviews")]
	public async Task<IActionResult> GetDiscountPreviews(Guid productId, CancellationToken cancellationToken, int optionId)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		IEnumerable<ProductsDiscountResponse> discountPreviews = await _serviceManager.CartService.GetDiscountsPreviewAsync(userId, productId, optionId, cancellationToken);
		return Ok(discountPreviews);
	}

	[HttpGet("myCart")]
	public async Task<IActionResult> GetMyCart(CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		CartResponse cart = await _serviceManager.CartService.GetByIdAsync(userId, cancellationToken);
		return Ok(cart);
	}

	[HttpPut("discount/{discountId}/AddProductToCart")]
	public async Task<IActionResult> AddProductToCartAsync([FromBody] PurchaseDetailDto cartItem, CancellationToken cancellationToken, Guid? discountId)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		CartResponse cart = await _serviceManager.CartService.AddProductToCartAsync(userId, discountId, cartItem, cancellationToken);
		return Ok(cart);
	}

	[HttpPut("/option/{optionId}/discounts/{discountId}/AddPackToCart")]
	public async Task<IActionResult> AddPackToCartAsync([FromBody] List<PurchaseDetailDto> cartItemsItems, CancellationToken cancellationToken, int optionId, Guid? discountId)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		CartResponse cart = await _serviceManager.CartService.AddPackToCartAsync(userId, discountId, optionId, cartItemsItems, cancellationToken);
		return Ok(cart);
	}

	[HttpPut("detail/{purchaseNumber}/option/{optionId}/adjust")]
	public async Task<IActionResult> AdjustCartItemQuantityAsync(int adjust, CancellationToken cancellationToken, int purchaseNumber, int optionId)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.CartService.AdjustCartItemQuantityAsync(userId, purchaseNumber, optionId, adjust, cancellationToken);
		return Ok();
	}

	[HttpPut("product/{productId:guid}/option/{optionId?}/remove")]
	public async Task<IActionResult> RemoveCartItemAsync(Guid productId, CancellationToken cancellationToken, int? optionId = 0)
	{
		if (optionId == 0)
			optionId = null;
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		CartResponse cart = await _serviceManager.CartService.RemoveCartItemAsync(userId, productId, optionId, cancellationToken);
		return Ok(cart);
	}

	[HttpPut("clear")]
	public async Task<IActionResult> ClearCartAsync(CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		CartResponse cart = await _serviceManager.CartService.ClearCartAsync(userId, cancellationToken);
		return Ok(cart);
	}
}