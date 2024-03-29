﻿using System.Net;
using System.Security.Claims;

using Contracts.Model.Product;
using Contracts.Model.Product.Response;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin, SalesManager")]
public class SuppliersController : ControllerBase
{
	private readonly IServiceManager _serviceManager;

	public SuppliersController(IServiceManager serviceManager)
	{
		_serviceManager = serviceManager;
	}

	[HttpGet("suppliersList")]
	public async Task<IActionResult> GetSuppliersList(CancellationToken cancellationToken)
	{
		IEnumerable<SuppliersListResponse> suppliers = await _serviceManager.SupplierService.GetSuppliersAsync(cancellationToken);
		return Ok(suppliers);
	}

	[HttpGet]
	public async Task<IActionResult> GetSuppliers(CancellationToken cancellationToken)
	{
		IEnumerable<SupplierResponse> suppliers = await _serviceManager.SupplierService.GetAllAsync(cancellationToken);
		return Ok(suppliers);
	}

	[HttpGet("{supplierId:guid}")]
	public async Task<IActionResult> GetSupplierById(Guid supplierId, CancellationToken cancellationToken)
	{
		SupplierResponse supplier = await _serviceManager.SupplierService.GetByIdAsync(supplierId, cancellationToken);
		return Ok(supplier);
	}

	[HttpPost]
	public async Task<IActionResult> CreateSupplier([FromBody] SupplierDto supplierDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.SupplierService.CreateAsync(userId, supplierDto, cancellationToken);
		return Ok();
	}

	[HttpPut("{supplierId:guid}")]
	public async Task<IActionResult> UpdateSupplier(Guid supplierId, [FromBody] SupplierDto supplierDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.SupplierService.UpdateAsync(userId, supplierId, supplierDto, cancellationToken);
		return Ok();
	}

	[HttpDelete("{supplierId:guid}")]
	public async Task<IActionResult> DeleteSupplier(Guid supplierId, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.SupplierService.DeleteAsync(userId, supplierId, cancellationToken);
		return Ok();
	}

	[HttpDelete("{supplierId:guid}/products/{productId:guid}")]
	public async Task<IActionResult> DeleteProductFromSupplier(Guid supplierId, Guid productId, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.SupplierService.DeleteProductFromSupplierAsync(userId, supplierId, productId, cancellationToken);
		return Ok();
	}
}