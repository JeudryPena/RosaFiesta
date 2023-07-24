﻿using System.Net;
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

	[HttpGet("myCart")]
	public async Task<IActionResult> GetMyCartAsync(CancellationToken cancellationToken)
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
		await _serviceManager.CartService.AddProductToCartAsync(userId, cartItem, cancellationToken);
		return Ok();
	}

	[HttpPut("/option/{optionId:guid}/AddPackToCart")]
	public async Task<IActionResult> AddPackToCartAsync([FromBody] List<PurchaseDetailDto> cartItemsItems, CancellationToken cancellationToken, Guid optionId)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.CartService.AddPackToCartAsync(userId, optionId, cartItemsItems, cancellationToken);
		return Ok();
	}

	[HttpPut("detail/{detailId:guid}/option/{optionId:guid}/adjust")]
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
		await _serviceManager.CartService.RemoveCartItemAsync(userId, productId, optionId, cancellationToken);
		return Ok();
	}

	[HttpPut("clear")]
	public async Task<IActionResult> ClearCartAsync(CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.CartService.ClearCartAsync(userId, cancellationToken);
		return Ok();
	}
}