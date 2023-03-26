using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract;
using Microsoft.AspNetCore.Mvc;

using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartsController : ControllerBase {
    private readonly IServiceManager _serviceManager;

    public CartsController(IServiceManager serviceManager) {
        _serviceManager = serviceManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetCarts(CancellationToken cancellationToken) {
        IEnumerable<CartResponse> carts = await _serviceManager.CartService.GetAllAsync(cancellationToken);
        return Ok(carts);
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetCart(string userId, CancellationToken cancellationToken) {
        CartResponse cart = await _serviceManager.CartService.GetByIdAsync(userId, cancellationToken);
        return Ok(cart);
    }
    
    [HttpPut("{userId}/AddProductToCart")]
    public async Task<IActionResult> AddProductToCartAsync(string userId, [FromBody] PurchaseDetailDto cartItem, CancellationToken cancellationToken) {
        CartResponse cart = await _serviceManager.CartService.AddProductToCartAsync(userId, cartItem, cancellationToken);
        return Ok(cart);
    }

    [HttpPut("{userId}/AddPackToCart")]
    public async Task<IActionResult> AddPackToCartAsync(string userId, [FromBody] List<PurchaseDetailDto> cartItemsItems, CancellationToken cancellationToken) {
        CartResponse cart = await _serviceManager.CartService.AddPackToCartAsync(userId, cartItemsItems, cancellationToken);
        return Ok(cart);
    }
    
    [HttpPut("{userId}/product/{productId}/adjust")]
    public async Task<IActionResult> AdjustCartItemQuantityAsync(string userId, string productId, int adjust, CancellationToken cancellationToken) {
        CartResponse cart = await _serviceManager.CartService.AdjustCartItemQuantityAsync(userId, productId, adjust, cancellationToken);
        return Ok(cart);
    }
    
    [HttpPut("{userId}/product/{productId}/remove")]
    public async Task<IActionResult> RemoveCartItemAsync(string userId, string productId, CancellationToken cancellationToken) {
        CartResponse cart = await _serviceManager.CartService.RemoveCartItemAsync(userId, productId, cancellationToken);
        return Ok(cart);
    }
    
    [HttpPut("{userId}/clear")]
    public async Task<IActionResult> ClearCartAsync(string userId, CancellationToken cancellationToken) {
        CartResponse cart = await _serviceManager.CartService.ClearCartAsync(userId, cancellationToken);
        return Ok(cart);
    }
}