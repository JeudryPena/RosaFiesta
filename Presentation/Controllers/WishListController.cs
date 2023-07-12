using System.Net;
using System.Security.Claims;

using Contracts.Model.Product.UserInteract;
using Contracts.Model.Product.UserInteract.Response;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class WishListController : ControllerBase
{
	private readonly IServiceManager _serviceManager;

	public WishListController(IServiceManager serviceManager)
	{
		_serviceManager = serviceManager;
	}

	[HttpGet]
	public async Task<IActionResult> GetWishListAsync(CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		WishListResponse wishListResponse = await _serviceManager.WishListService.GetWishListAsync(userId, cancellationToken);
		return Ok(wishListResponse);
	}

	[HttpPost("createWishList")]
	public async Task<IActionResult> CreateWishListAsync([FromBody] WishListDto wishList, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.WishListService.CreateWishListAsync(wishList, userId, cancellationToken);
		return Ok();
	}

	[HttpPost("products")]
	public async Task<IActionResult> AddProductsToWishListAsync(List<ProductsWishListDto> productsWishListDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.WishListService.AddProductToWishListAsync(userId, productsWishListDto, cancellationToken);
		return Ok();
	}

	[HttpDelete("{wishListId:guid}/option/{optionId:guid}")]
	public async Task<IActionResult> DeleteProductFromWishListAsync(Guid wishListId, CancellationToken cancellationToken, int optionId)
	{
		await _serviceManager.WishListService.DeleteProductFromWishListAsync(wishListId, optionId, cancellationToken);
		return Ok();
	}

	[HttpDelete("deleteAll")]
	public async Task<IActionResult> DeleteAllProductsFromWishListAsync(CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.WishListService.DeleteAllProductsFromWishListAsync(userId, cancellationToken);
		return Ok();
	}
}