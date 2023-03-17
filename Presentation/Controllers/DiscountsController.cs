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
     public async Task<IActionResult> GetDiscounts(CancellationToken cancellationToken)
     {
          IEnumerable<DiscountResponse> discounts = await _serviceManager.DiscountService.GetAllAsync(cancellationToken);
          return Ok(discounts);
     }
    
     [HttpGet("{discountCode}")]
     public async Task<IActionResult> GetDiscount(string discountCode, CancellationToken cancellationToken)
     {
          DiscountResponse discount = await _serviceManager.DiscountService.GetDiscountAsync(discountCode, cancellationToken);
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

     [HttpPut("{discountCode}")]
     [Authorize]
     public async Task<IActionResult> UpdateDiscount(string discountCode,[FromBody] DiscountDto discountDto, CancellationToken cancellationToken)
     {
          string? username = User.Identity?.Name;
          DiscountResponse discountResponse = await _serviceManager.DiscountService.UpdateDiscountAsync(username, discountCode, discountDto, cancellationToken);
          return Ok(discountResponse);
     }
    
     [HttpDelete("{discountCode}")]
     public async Task<IActionResult> DeleteDiscount(string discountCode, CancellationToken cancellationToken)
     {
          await _serviceManager.DiscountService.DeleteDiscountAsync(discountCode, cancellationToken);
          return Ok();
     }
}