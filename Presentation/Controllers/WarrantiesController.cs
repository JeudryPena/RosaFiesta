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
public class WarrantiesController : ControllerBase
{
	private readonly IServiceManager _serviceManager;

	public WarrantiesController(IServiceManager serviceManager)
	{
		_serviceManager = serviceManager;
	}

	[HttpGet]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> GetWarranties(CancellationToken cancellationToken)
	{
		IEnumerable<WarrantyResponse> suppliers = await _serviceManager.WarrantyService.GetAllAsync(cancellationToken);
		return Ok(suppliers);
	}

	[HttpGet("{warrantyId:guid}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> GetWarranty(Guid warrantyId, CancellationToken cancellationToken)
	{
		WarrantyResponse warranty = await _serviceManager.WarrantyService.GetWarrantyAsync(warrantyId, cancellationToken);
		return Ok(warranty);
	}

	[HttpPost]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> CreateWarranty([FromBody] WarrantyDto warranty, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		WarrantyResponse warrantyResponse = await _serviceManager.WarrantyService.CreateWarrantyAsync(userId, warranty, cancellationToken);
		return Ok(warrantyResponse);
	}

	[HttpPut("{warrantyId:guid}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> UpdateWarranty(Guid warrantyId, [FromBody] WarrantyDto warrantyDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		WarrantyResponse warrantyResponse = await _serviceManager.WarrantyService.UpdateWarrantyAsync(userId, warrantyId, warrantyDto, cancellationToken);
		return Ok(warrantyResponse);
	}

	[HttpPut("{warrantyId:guid}/status")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> UpdateWarrantyStatus(Guid warrantyId, [FromBody] int warrantyStatus, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		WarrantyResponse warrantyResponse = await _serviceManager.WarrantyService.UpdateWarrantyStatusAsync(userId, warrantyId, warrantyStatus, cancellationToken);
		return Ok(warrantyResponse);
	}

	[HttpDelete("{warrantyId:guid}/delete")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> DeleteWarranty(Guid warrantyId, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.WarrantyService.DeleteWarrantyAsync(userId, warrantyId, cancellationToken);
		return Ok();
	}
}