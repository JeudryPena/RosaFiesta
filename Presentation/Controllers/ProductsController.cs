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
public class ProductsController : ControllerBase
{
	private readonly IServiceManager _serviceManager;

	public ProductsController(IServiceManager serviceManager)
	{
		_serviceManager = serviceManager;
	}

	[HttpGet]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> GetManagementProducts(CancellationToken cancellationToken)
	{
		ICollection<ManagementProductsResponse> products = await _serviceManager.ProductService.ManagementGetAllAsync(cancellationToken);
		return Ok(products);
	}

	[HttpGet("options")]
	public async Task<IActionResult> GetProductsPreview(CancellationToken cancellationToken)
	{
		ICollection<ProductPreviewResponse> options = await _serviceManager.ProductService.GetAllAsyncPreview(cancellationToken);
		return Ok(options);
	}

	[HttpGet("{productCode:guid}/option/{optionId}/productDetail")]
	[Authorize]
	public async Task<IActionResult> GetProductDetail(Guid productCode, int optionId, CancellationToken cancellationToken)
	{
		ProductDetailResponse productAndOption = await _serviceManager.ProductService.GetProductDetail(productCode, optionId, cancellationToken);
		return Ok(productAndOption);
	}

	[HttpGet("{productCode:guid}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> GetProductById(Guid productCode, CancellationToken cancellationToken)
	{
		ProductResponse productAndOption = await _serviceManager.ProductService.GetByIdAsync(productCode, cancellationToken);
		return Ok(productAndOption);
	}

	[HttpGet("options-list")]
	public async Task<IActionResult> GetOptions(CancellationToken cancellationToken)
	{
		IEnumerable<OptionsListResponse> options = await _serviceManager.ProductService.GetOptionsAsync(cancellationToken);
		return Ok(options);
	}

	[HttpPost]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> CreateProduct([FromBody] ProductDto productForCreationDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.ProductService.CreateAsync(userId, productForCreationDto, cancellationToken);
		return Ok();
	}

	[HttpPut("{productCode:guid}/option/{optionId}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> UpdateProduct(Guid productId, int optionId, [FromBody] ProductUpdateDto productForUpdateDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.ProductService.UpdateAsync(userId, optionId, productId, productForUpdateDto, cancellationToken);
		return Ok();
	}


	[HttpPut("{productCode:guid}/options/{optionId}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> AdjustOptionQuantity(Guid productId, int optionId, int count, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		OptionAdjustResponse products = await _serviceManager.ProductService.AdjustOptionQuantityAsync(userId, optionId, productId, count, cancellationToken);
		return Ok(products);
	}

	[HttpDelete("{productCode:guid}/option/{optionId?}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> DeleteProductOrOption(Guid productId, CancellationToken cancellationToken, int? optionId = 0)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		if (optionId != 0)
			optionId = null;
		await _serviceManager.ProductService.DeleteAsync(userId, productId, optionId, cancellationToken);
		return Ok();
	}
}