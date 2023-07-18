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

	[HttpGet("options-list")]
	public async Task<IActionResult> GetOptionsList(CancellationToken cancellationToken)
	{
		ICollection<OptionsListResponse> options = await _serviceManager.ProductService.GetOptionsList(cancellationToken);
		return Ok(options);
	}

	[HttpGet("productsList")]
	public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
	{
		ICollection<ProductsListResponse> products = await _serviceManager.ProductService.GetProductsList(cancellationToken);
		return Ok(products);
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

	[HttpGet("{productId:guid}/option/{optionId:guid}/productDetail")]
	[Authorize]
	public async Task<IActionResult> GetProductDetail(Guid productId, Guid optionId, CancellationToken cancellationToken)
	{
		ProductDetailResponse productAndOption = await _serviceManager.ProductService.GetProductDetail(productId, optionId, cancellationToken);
		return Ok(productAndOption);
	}

	[HttpGet("{productId:guid}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> GetProductById(Guid productId, CancellationToken cancellationToken)
	{
		ProductResponse productAndOption = await _serviceManager.ProductService.GetByIdAsync(productId, cancellationToken);
		return Ok(productAndOption);
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

	[HttpPut("{productId:guid}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> UpdateProduct(Guid productId, [FromBody] ProductDto productForUpdateDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.ProductService.UpdateAsync(userId, productId, productForUpdateDto, cancellationToken);
		return Ok();
	}


	[HttpPut("{productId:guid}/options/{optionId:guid}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> AdjustOptionQuantity(Guid productId, Guid optionId, int count, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.ProductService.AdjustOptionQuantityAsync(userId, optionId, productId, count, cancellationToken);
		return Ok();
	}

	[HttpDelete("{productId:guid}/option/{optionId:Guid?}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> DeleteProductOrOption(Guid productId, CancellationToken cancellationToken, Guid? optionId = null)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.ProductService.DeleteAsync(userId, productId, optionId, cancellationToken);
		return Ok();
	}
}