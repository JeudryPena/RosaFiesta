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

	[HttpGet("warrantiesList")]
	[Authorize(Roles = "Admin, ProductsManager")]
	public async Task<IActionResult> GetWarrantiesForAdmin(CancellationToken cancellationToken)
	{
		IEnumerable<WarrantiesListResponse> warranties = await _serviceManager.WarrantyService.GetAllForAdminAsync(cancellationToken);
		return Ok(warranties);
	}

	[HttpGet("management")]
	[Authorize(Roles = "Admin, ProductsManager")]
	public async Task<IActionResult> GetWarrantiesForManagement(CancellationToken cancellationToken)
	{
		IEnumerable<WarrantiesManagementResponse> warranties = await _serviceManager.WarrantyService.GetAllForManagementAsync(cancellationToken);
		return Ok(warranties);
	}

	[HttpGet]
	public async Task<IActionResult> GetWarranties(CancellationToken cancellationToken)
	{
		IEnumerable<WarrantyPreviewResponse> suppliers = await _serviceManager.WarrantyService.GetAllAsync(cancellationToken);
		return Ok(suppliers);
	}

	[HttpGet("{warrantyId:guid}")]
	[Authorize(Roles = "Admin, ProductsManager")]
	public async Task<IActionResult> GetManagementWarranty(Guid warrantyId, CancellationToken cancellationToken)
	{
		WarrantyResponse warranty = await _serviceManager.WarrantyService.GetWarrantyAsync(warrantyId, cancellationToken);
		return Ok(warranty);
	}
	
	[HttpGet("{warrantyId:guid}/preview")]
	public async Task<IActionResult> GetWarrantyPreview(Guid warrantyId, CancellationToken cancellationToken)
	{
		WarrantyPreviewResponse warranty = await _serviceManager.WarrantyService.GetWarrantyPreviewAsync(warrantyId, cancellationToken);
		return Ok(warranty);
	}
	
	[HttpGet("product/{productId:guid}/preview")]
	public async Task<IActionResult> GetWarrantyPreviewByProductIdAsync(Guid warrantyId, CancellationToken cancellationToken)
	{
		Guid? id = await _serviceManager.WarrantyService.GetWarrantyPreviewByProductIdAsync(warrantyId, cancellationToken);
		if(id == null)
			return NotFound();
		return Ok(id);
	}

	[HttpPost]
	[Authorize(Roles = "Admin, ProductsManager")]
	public async Task<IActionResult> CreateWarranty([FromBody] WarrantyDto warranty, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.WarrantyService.CreateWarrantyAsync(userId, warranty, cancellationToken);
		return Ok();
	}

	[HttpPut("{warrantyId:guid}")]
	[Authorize(Roles = "Admin, ProductsManager")]
	public async Task<IActionResult> UpdateWarranty(Guid warrantyId, [FromBody] WarrantyDto warrantyDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.WarrantyService.UpdateWarrantyAsync(userId, warrantyId, warrantyDto, cancellationToken);
		return Ok();
	}

	[HttpPut("{warrantyId:guid}/status")]
	[Authorize(Roles = "Admin, ProductsManager")]
	public async Task<IActionResult> UpdateWarrantyStatus(Guid warrantyId, [FromBody] int warrantyStatus, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.WarrantyService.UpdateWarrantyStatusAsync(userId, warrantyId, warrantyStatus, cancellationToken);
		return Ok();
	}

	[HttpDelete("{warrantyId:guid}")]
	[Authorize(Roles = "Admin, ProductsManager")]
	public async Task<IActionResult> DeleteWarranty(Guid warrantyId, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.WarrantyService.DeleteWarrantyAsync(userId, warrantyId, cancellationToken);
		return Ok();
	}

	[HttpDelete("{warrantyId:guid}/products/{productId:guid}")]
	[Authorize(Roles = "Admin, ProductsManager")]
	public async Task<IActionResult> DeleteWarrantyProduct(Guid warrantyId, Guid productId, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.WarrantyService.DeleteWarrantyProductAsync(userId, warrantyId, productId, cancellationToken);
		return Ok();
	}
}