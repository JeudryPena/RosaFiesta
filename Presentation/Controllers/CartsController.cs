using System.Net;
using System.Security.Claims;
using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CartsController : ControllerBase {
    private readonly IServiceManager _serviceManager;

    public CartsController(IServiceManager serviceManager) {
        _serviceManager = serviceManager;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetCarts(CancellationToken cancellationToken) {
        IEnumerable<CartResponse> carts = await _serviceManager.CartService.GetAllAsync(cancellationToken);
        return Ok(carts);
    }
    
    [HttpGet("product/{productCode}/option/{optionId}/discountPreviews")]
    public async Task<IActionResult> GetDiscountPreviews(string productCode, int? optionId, CancellationToken cancellationToken)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        IEnumerable<ProductsDiscountResponse> discountPreviews = await _serviceManager.CartService.GetDiscountsPreviewAsync(userId, productCode, optionId, cancellationToken);
        return Ok(discountPreviews);
    }

    [HttpGet("{userId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetCart(string userId, CancellationToken cancellationToken) {
        CartResponse cart = await _serviceManager.CartService.GetByIdAsync(userId, cancellationToken);
        return Ok(cart);
    }
    
    [HttpGet("myCart")]
    public async Task<IActionResult> GetMyCart(CancellationToken cancellationToken) {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        CartResponse cart = await _serviceManager.CartService.GetByIdAsync(userId,cancellationToken);
        return Ok(cart);
    }
    
    [HttpPut("discount/{discountCode}/AddProductToCart")]
    public async Task<IActionResult> AddProductToCartAsync([FromBody] PurchaseDetailDto cartItem, string? discountCode, CancellationToken cancellationToken) {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        CartResponse cart = await _serviceManager.CartService.AddProductToCartAsync(userId, discountCode, cartItem, cancellationToken);
        return Ok(cart);
    }

    [HttpPut("AddPackToCart")]
    public async Task<IActionResult> AddPackToCartAsync([FromBody] List<PurchaseDetailDto> cartItemsItems, CancellationToken cancellationToken) {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        CartResponse cart = await _serviceManager.CartService.AddPackToCartAsync(userId, cartItemsItems, cancellationToken);
        return Ok(cart);
    }
    
    [HttpPut("product/{productId}/adjust")]
    public async Task<IActionResult> AdjustCartItemQuantityAsync(string productId, int adjust, CancellationToken cancellationToken) {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        CartResponse cart = await _serviceManager.CartService.AdjustCartItemQuantityAsync(userId, productId, adjust, cancellationToken);
        return Ok(cart);
    }
    
    [HttpPut("product/{productId}/remove")]
    public async Task<IActionResult> RemoveCartItemAsync(string productId, CancellationToken cancellationToken) {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        CartResponse cart = await _serviceManager.CartService.RemoveCartItemAsync(userId, productId, cancellationToken);
        return Ok(cart);
    }
    
    [HttpPut("clear")]
    public async Task<IActionResult> ClearCartAsync(CancellationToken cancellationToken) {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        CartResponse cart = await _serviceManager.CartService.ClearCartAsync(userId, cancellationToken);
        return Ok(cart);
    }
}