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

	[HttpGet]
	public async Task<IActionResult> GetCartDetailsCountAsync(CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		int count = await _serviceManager.CartService.GetCartDetailsCountAsync(userId, cancellationToken);
		return Ok(count);
	}

	[HttpGet("myCart")]
	public async Task<IActionResult> GetMyCartAsync(CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		CartResponse cart = await _serviceManager.CartService.GetByIdAsync(userId, cancellationToken);
		return Ok(cart);
	}

	/// <summary>
	/// Verify if the item is in stock
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <param name="detailId"></param>
	/// <param name="optionId"></param>
	/// <param name="quantity"></param>
	/// <returns></returns>
	[HttpGet]
	[Route("detail/{detailId:guid}/option/{optionId:guid}/quantity/{quantity:int}")]
	public async Task<IActionResult> VerifyItemStockAsync(CancellationToken cancellationToken, Guid detailId, Guid optionId, int quantity)
	{
		await _serviceManager.CartService.VerifyItemStockAsync(detailId, optionId, quantity, cancellationToken);
		return Ok();
	}

	[HttpPut("addProductToCart")]
	public async Task<IActionResult> AddProductToCartAsync([FromBody] PurchaseDetailDto cartItem, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.CartService.AddProductToCartAsync(userId, cartItem, cancellationToken);
		return Ok();
	}

	[HttpPut("/option/{optionId:guid}/addPackToCart")]
	public async Task<IActionResult> AddPackToCartAsync([FromBody] List<PurchaseDetailDto> cartItemsItems, CancellationToken cancellationToken, Guid optionId)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.CartService.AddPackToCartAsync(userId, optionId, cartItemsItems, cancellationToken);
		return Ok();
	}

	[HttpGet("detail/{detailId:guid}/option/{optionId:guid}/adjust/{quantity:int}")]
	public async Task<IActionResult> AdjustCartItemQuantityAsync(int quantity, CancellationToken cancellationToken, Guid detailId, Guid optionId)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.CartService.AdjustCartItemQuantityAsync(userId, detailId, optionId, quantity, cancellationToken);
		return Ok();
	}

	[HttpDelete("detail/{detailId:guid}/option/{optionId:guid?}/remove")]
	public async Task<IActionResult> RemoveCartItemAsync(Guid detailId, CancellationToken cancellationToken, Guid? optionId = null)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.CartService.RemoveCartItemAsync(userId, detailId, optionId, cancellationToken);
		return Ok();
	}

	[HttpDelete("clear")]
	public async Task<IActionResult> ClearCartAsync(CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.CartService.ClearCartAsync(userId, cancellationToken);
		return Ok();
	}
}