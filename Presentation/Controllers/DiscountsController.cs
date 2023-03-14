using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DiscountsController: ControllerBase
{
     private readonly IServiceManager _serviceManager;
     
     public DiscountsController(IServiceManager serviceManager)
     {
          _serviceManager = serviceManager;
     }
     
     [HttpGet]
     public async Task<IActionResult> GetDiscount(CancellationToken cancellationToken)
     {
          IEnumerable<DiscountResponse> discounts = await _serviceManager.DiscountService.GetAllAsync(cancellationToken);
          return Ok(discounts);
     }
    
     [HttpGet("{discountId:guid}")]
     public async Task<IActionResult> GetDiscount(Guid discountId, CancellationToken cancellationToken)
     {
          DiscountResponse discount = await _serviceManager.DiscountService.GetDiscountAsync(discountId, cancellationToken);
          return Ok(discount);
     }
    
     [HttpPost]
     [Authorize]
     public async Task<IActionResult> CreateDiscount([FromBody] DiscountDto discount, CancellationToken cancellationToken)
     {
          string? username = User.Identity?.Name;
          DiscountResponse discountResponse = await _serviceManager.DiscountService.CreateDiscountAsync(username, discount, cancellationToken);
          return Ok(discountResponse);
     }

     [HttpPut("{discountId:guid}")]
     [Authorize]
     public async Task<IActionResult> UpdateDiscount(Guid discountId,[FromBody] DiscountDto discountDto, CancellationToken cancellationToken)
     {
          string? username = User.Identity?.Name;
          DiscountResponse discountResponse = await _serviceManager.DiscountService.UpdateDiscountAsync(username, discountId, discountDto, cancellationToken);
          return Ok(discountResponse);
     }
    
     [HttpDelete("{discountId:guid}")]
     public async Task<IActionResult> DeleteDiscount(Guid discountId, CancellationToken cancellationToken)
     {
          await _serviceManager.DiscountService.DeleteDiscountAsync(discountId, cancellationToken);
          return Ok();
     }
}