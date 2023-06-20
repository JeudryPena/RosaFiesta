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

	[HttpGet("{Code}/management")]
	public async Task<IActionResult> GetManagementDiscount(string code, CancellationToken cancellationToken)
	{
		ManagementDiscountsResponse discount = await _serviceManager.DiscountService.GetManagementDiscountAsync(code, cancellationToken);
		return Ok(discount);
	}

	[HttpGet("{Code}")]
	public async Task<IActionResult> GetDiscount(string Code, CancellationToken cancellationToken)
	{
		DiscountResponse discount = await _serviceManager.DiscountService.GetDiscountAsync(Code, cancellationToken);
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

	[HttpPut("{Code}")]
	public async Task<IActionResult> UpdateDiscount(string Code, [FromBody] DiscountDto discountDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.DiscountService.UpdateDiscountAsync(userId, Code, discountDto, cancellationToken);
		return Ok();
	}

	[HttpGet("{Code}/delete")]
	public async Task<IActionResult> DeleteDiscount(string Code, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.DiscountService.DeleteDiscountAsync(userId, Code, cancellationToken);
		return Ok();
	}
}