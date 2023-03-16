using Contracts.Model.Product;
using Contracts.Model.Product.Response;

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

    [HttpPost("{userId}")]
    public async Task<IActionResult> AddToCartAsync(string userId, [FromBody] List<PurchaseDetailDto> cartItemsItems, CancellationToken cancellationToken) {
        CartResponse cart = await _serviceManager.CartService.AddToCartAsync(userId, cartItemsItems, cancellationToken);
        return Ok(cart);
    }
    
    [HttpPut("{userId}/product/{productId}/adjust")]
    public async Task<IActionResult> AdjustCartItemQuantityAsync(string userId, string productId, int decrease, CancellationToken cancellationToken) {
        CartResponse cart = await _serviceManager.CartService.AdjustCartItemQuantityAsync(userId, productId, decrease, cancellationToken);
        return Ok(cart);
    }
}