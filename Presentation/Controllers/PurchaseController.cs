using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

public class PurchaseController: ControllerBase
{
    private readonly IServiceManager _serviceManager;
    
    public PurchaseController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    // Order purchase
    [HttpPost("{userId}/payMethod/{payMethodId:guid}")]
    public async Task<IActionResult> OrderPurchaseAsync(string userId, Guid payMethodId, [FromBody] OrderDto orderDto, CancellationToken cancellationToken)
    {
        OrderResponse cart = await _serviceManager.OrderService.OrderPurchaseAsync(userId, payMethodId, orderDto, cancellationToken);
        return Ok(cart);
    }
    
}