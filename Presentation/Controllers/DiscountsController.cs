using System.Net;
using System.Security.Claims;
using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize (Roles = "Admin")]
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
     public async Task<IActionResult> CreateDiscount([FromBody] DiscountDto discount, CancellationToken cancellationToken)
     {
          string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
          if (userId == null)
               return StatusCode((int) HttpStatusCode.Unauthorized);
          DiscountResponse discountResponse = await _serviceManager.DiscountService.CreateDiscountAsync(userId, discount, cancellationToken);
          return Ok(discountResponse);
     }

     [HttpPut("{discountCode}")]
     public async Task<IActionResult> UpdateDiscount(string discountCode,[FromBody] DiscountDto discountDto, CancellationToken cancellationToken)
     {
          string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
          if (userId == null)
               return StatusCode((int) HttpStatusCode.Unauthorized);
          DiscountResponse discountResponse = await _serviceManager.DiscountService.UpdateDiscountAsync(userId, discountCode, discountDto, cancellationToken);
          return Ok(discountResponse);
     }
    
     [HttpDelete("{discountCode}")]
     public async Task<IActionResult> DeleteDiscount(string discountCode, CancellationToken cancellationToken)
     {
          await _serviceManager.DiscountService.DeleteDiscountAsync(discountCode, cancellationToken);
          return Ok();
     }
}