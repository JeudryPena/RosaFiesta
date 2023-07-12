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
[Authorize(Roles = "Admin")]
public class DiscountsController : ControllerBase
{
	private readonly IServiceManager _serviceManager;

	public DiscountsController(IServiceManager serviceManager)
	{
		_serviceManager = serviceManager;
	}

	[HttpGet("management")]
	public async Task<IActionResult> GetManagementDiscounts(CancellationToken cancellationToken)
	{
		IEnumerable<ManagementDiscountsResponse> discounts = await _serviceManager.DiscountService.ManagementGetAllAsync(cancellationToken);
		return Ok(discounts);
	}

	[HttpGet("{discountId:guid}/management")]
	public async Task<IActionResult> GetManagementDiscount(Guid discountId, CancellationToken cancellationToken)
	{
		ManagementDiscountsResponse discount = await _serviceManager.DiscountService.GetManagementDiscountAsync(discountId, cancellationToken);
		return Ok(discount);
	}

	[HttpGet("{discountId:guid}")]
	public async Task<IActionResult> GetDiscount(Guid discountId, CancellationToken cancellationToken)
	{
		DiscountResponse discount = await _serviceManager.DiscountService.GetDiscountAsync(discountId, cancellationToken);
		return Ok(discount);
	}

	[HttpPost]
	public async Task<IActionResult> CreateDiscount([FromBody] DiscountDto discount, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.DiscountService.CreateDiscountAsync(userId, discount, cancellationToken);
		return Ok();
	}

	[HttpPut("{discountId:guid}")]
	public async Task<IActionResult> UpdateDiscount(Guid discountId, [FromBody] DiscountDto discountDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.DiscountService.UpdateDiscountAsync(userId, discountId, discountDto, cancellationToken);
		return Ok();
	}

	[HttpDelete("{discountId:guid}")]
	public async Task<IActionResult> DeleteDiscount(Guid discountId, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.DiscountService.DeleteDiscountAsync(userId, discountId, cancellationToken);
		return Ok();
	}

	[HttpDelete("{discountId:guid}/options/{optionId:Guid?}")]
	public async Task<IActionResult> DeleteDiscountProducts(Guid discountId, CancellationToken cancellationToken, Guid? optionId = null)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.DiscountService.DeleteDiscountProductsAsync(userId, discountId, optionId, cancellationToken);
		return Ok();
	}

}