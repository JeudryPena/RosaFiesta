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

	[HttpGet("product/{productCode}/option/{optionId}/discountPreviews")]
	public async Task<IActionResult> GetDiscountPreviews(string productCode, CancellationToken cancellationToken, int optionId)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		IEnumerable<ProductsDiscountResponse> discountPreviews = await _serviceManager.CartService.GetDiscountsPreviewAsync(userId, productCode, optionId, cancellationToken);
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

	[HttpPut("discount/{Code?}/AddProductToCart")]
	public async Task<IActionResult> AddProductToCartAsync([FromBody] PurchaseDetailDto cartItem, CancellationToken cancellationToken, string? Code = " ")
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		if (Code == " ")
			Code = null;
		CartResponse cart = await _serviceManager.CartService.AddProductToCartAsync(userId, Code, cartItem, cancellationToken);
		return Ok(cart);
	}

	[HttpPut("/option/{optionId}/discount/{Code?}/AddPackToCart")]
	public async Task<IActionResult> AddPackToCartAsync([FromBody] List<PurchaseDetailDto> cartItemsItems, CancellationToken cancellationToken, int optionId, string? Code = " ")
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		if (Code == " ")
			Code = null;
		CartResponse cart = await _serviceManager.CartService.AddPackToCartAsync(userId, optionId, Code, cartItemsItems, cancellationToken);
		return Ok(cart);
	}

	[HttpPut("detail/{purchaseNumber}/option/{optionId}/adjust")]
	public async Task<IActionResult> AdjustCartItemQuantityAsync(int adjust, CancellationToken cancellationToken, int purchaseNumber, int optionId)
	{
		await _serviceManager.CartService.AdjustCartItemQuantityAsync(purchaseNumber, optionId, adjust, cancellationToken);
		return Ok();
	}

	[HttpPut("product/{productId}/option/{optionId?}/remove")]
	public async Task<IActionResult> RemoveCartItemAsync(string productId, CancellationToken cancellationToken, int? optionId = 0)
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