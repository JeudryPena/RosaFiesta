using System.Net;
using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract;
using Contracts.Model.Product.UserInteract.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WishListController: ControllerBase
{
    private readonly IServiceManager _serviceManager;
    
    public WishListController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetWishListsAsync(CancellationToken cancellationToken)
    {
        var value = User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;
        if (value == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        string userId = value;
        IEnumerable<WishListPreviewResponse> wishListResponse = await _serviceManager.WishListService.GetWishListsAsync(userId, cancellationToken);
        return Ok(wishListResponse);
    }
    
    [HttpGet("{wishListId}")]
    public async Task<IActionResult> GetWishListAsync(int wishListId, CancellationToken cancellationToken)
    {
        WishListResponse wishListResponse = await _serviceManager.WishListService.GetWishListAsync(wishListId, cancellationToken);
        return Ok(wishListResponse);
    }
    
    [HttpPost("{userId}")]
    public async Task<IActionResult> CreateWishListAsync([FromBody] WishListDto wishList, string userId, CancellationToken cancellationToken)
    {
        WishListResponse wishListResponse = await _serviceManager.WishListService.CreateWishListAsync(wishList, userId, cancellationToken);
        return Ok(wishListResponse);
    }
    
    [HttpPost("{wishListId}/products")]
    public async Task<IActionResult> AddProductsToWishListAsync(int wishListId, List<string> productsId, CancellationToken cancellationToken)
    {
        WishListProductsResponse wishListProductResponse = await _serviceManager.WishListService.AddProductToWishListAsync(wishListId, productsId, cancellationToken);
        return Ok(wishListProductResponse);
    }
    
    [HttpDelete("{wishListId}/products/{productId}")]
    public async Task<IActionResult> DeleteProductFromWishListAsync(int wishListId, string productId, CancellationToken cancellationToken)
    {
        WishListProductsResponse wishListProductResponse = await _serviceManager.WishListService.DeleteProductFromWishListAsync(wishListId, productId, cancellationToken);
        return Ok(wishListProductResponse);
    }
    
    [HttpDelete("{wishListId}")]
    public async Task<IActionResult> DeleteAllProductsFromWishListAsync(int wishListId, CancellationToken cancellationToken)
    {
        await _serviceManager.WishListService.DeleteAllProductsFromWishListAsync(wishListId, cancellationToken);
        return Ok();
    }
    
    [HttpDelete("{wishListId}")]
    public async Task<IActionResult> DeleteWishListAsync(int wishListId, CancellationToken cancellationToken)
    {
        await _serviceManager.WishListService.DeleteWishListAsync(wishListId, cancellationToken);
        return Ok();
    }
    
    [HttpDelete("deleteAll")]
    public async Task<IActionResult> DeleteAllWishListsAsync(CancellationToken cancellationToken)
    {
        var value = User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;
        if (value == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        string userId = value;
        await _serviceManager.WishListService.DeleteAllWishListsAsync(userId, cancellationToken);
        return Ok();
    }

    [HttpPut("{wishListId}")]
    public async Task<IActionResult> UpdateWishListAsync(int wishListId, [FromBody] WishListDto wishList, CancellationToken cancellationToken)
    {
        var value = User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;
        if (value == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        string userId = value;
        WishListResponse wishListResponse = await _serviceManager.WishListService.UpdateWishListAsync(userId, wishListId, wishList, cancellationToken);
        return Ok(wishListResponse);
    }
}