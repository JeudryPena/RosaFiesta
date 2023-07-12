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

	[HttpGet("options/{optionId:guid}/discountPreviews")]
	public async Task<IActionResult> GetDiscountPreviews(CancellationToken cancellationToken, Guid optionId)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		IEnumerable<ProductsDiscountResponse> discountPreviews = await _serviceManager.CartService.GetDiscountsPreviewAsync(userId, optionId, cancellationToken);
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

	[HttpPut("AddProductToCart")]
	public async Task<IActionResult> AddProductToCartAsync([FromBody] PurchaseDetailDto cartItem, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		CartResponse cart = await _serviceManager.CartService.AddProductToCartAsync(userId, cartItem, cancellationToken);
		return Ok(cart);
	}

	[HttpPut("/option/{optionId:guid}/AddPackToCart")]
	public async Task<IActionResult> AddPackToCartAsync([FromBody] List<PurchaseDetailDto> cartItemsItems, CancellationToken cancellationToken, Guid optionId)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		CartResponse cart = await _serviceManager.CartService.AddPackToCartAsync(userId, optionId, cartItemsItems, cancellationToken);
		return Ok(cart);
	}

	[HttpPut("detail/{detailId:guid}/option/{detailId:guid}/adjust")]
	public async Task<IActionResult> AdjustCartItemQuantityAsync(int adjust, CancellationToken cancellationToken, Guid purchaseNumber, Guid optionId)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.CartService.AdjustCartItemQuantityAsync(userId, purchaseNumber, optionId, adjust, cancellationToken);
		return Ok();
	}

	[HttpPut("product/{productId:guid}/option/{optionId:guid?}/remove")]
	public async Task<IActionResult> RemoveCartItemAsync(Guid productId, CancellationToken cancellationToken, Guid? optionId = null)
	{
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