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
	
	[HttpGet("count-views")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> RetrieveCountViews(CancellationToken cancellationToken)
	{
		int count = await _serviceManager.ProductService.GetCountViews(cancellationToken);
		return Ok(count);
	}

	[HttpGet("options-list")]
	public async Task<IActionResult> OptionsList(CancellationToken cancellationToken)
	{
		ICollection<OptionsListResponse> options = await _serviceManager.ProductService.GetOptionsList(cancellationToken);
		return Ok(options);
	}

	[HttpGet("productsList")]
	public async Task<IActionResult> RetrieveProducts(CancellationToken cancellationToken)
	{
		ICollection<ProductsListResponse> products = await _serviceManager.ProductService.GetProductsList(cancellationToken);
		return Ok(products);
	}

	[HttpGet]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> RetrieveManagementAsync(CancellationToken cancellationToken)
	{
		ICollection<ManagementProductsResponse> products = await _serviceManager.ProductService.ManagementGetAllAsync(cancellationToken);
		return Ok(products);
	}

	[HttpGet("options")]
	public async Task<IActionResult> RetrievePreviewAsync(CancellationToken cancellationToken)
	{
		ICollection<ProductPreviewResponse> options = await _serviceManager.ProductService.GetAllAsyncPreview(cancellationToken);
		return Ok(options);
	}

	[HttpGet("{productId:guid}/option/{optionId:guid}/detail")]
	public async Task<IActionResult> RetrieveProductDetailAsync(Guid productId, Guid optionId, CancellationToken cancellationToken)
	{
		ProductDetailResponse productAndOption = await _serviceManager.ProductService.GetProductDetail(productId, optionId, cancellationToken);
		return Ok(productAndOption);
	}

	[HttpGet("{productId:guid}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> RetrieveByIdAsync(Guid productId, CancellationToken cancellationToken)
	{
		ProductResponse productAndOption = await _serviceManager.ProductService.GetByIdAsync(productId, cancellationToken);
		return Ok(productAndOption);
	}
	
	/// <summary>
	/// This endpoint is used to increase the view count of a product.
	/// </summary>
	/// <param name="productId"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[HttpGet("{productId:guid}/view")]
	public async Task<IActionResult> ViewAsync(Guid productId, CancellationToken cancellationToken)
	{
		await _serviceManager.ProductService.ViewAsync(productId, cancellationToken);
		return Ok();
	}
	
	/// <summary>
	/// This endpoint is used to retrieve the recommended products.
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[HttpGet("recommended-products")]
	public async Task<IActionResult> RetrieveRecommendedProductsAsync(CancellationToken cancellationToken)
	{
		ICollection<ProductPreviewResponse> products = await _serviceManager.ProductService.GetRecommendedProducts(cancellationToken);
		return Ok(products);
	}
	
	[HttpGet("related-products/{categoryId:int}")]
	public async Task<IActionResult> RetrieveRelatedProductsAsync(CancellationToken cancellationToken,
		int categoryId)
	{
		ICollection<ProductPreviewResponse> products = await _serviceManager.ProductService.GetRelatedProducts(categoryId, cancellationToken);
		return Ok(products);
	}
	
	[HttpPost("filtered")]
	public async Task<IActionResult> RetrieveFilteredAsync(FilteredSearchDto filter, CancellationToken cancellationToken)
	{
		ICollection<ProductPreviewResponse> products = await _serviceManager.ProductService.FilterProductAsyncPreview(filter, cancellationToken);
		return Ok(products);
	}
	
	[HttpPost("search")]
	public async Task<IActionResult> SearchProductsAsync(FilteredSearchDto filter, CancellationToken cancellationToken)
	{
		ICollection<ProductPreviewResponse> products = await _serviceManager.ProductService.SearchProductsAsync(filter, cancellationToken);
		return Ok(products);
	}

	[HttpPost]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> PersistAsync([FromBody] ProductDto productForCreationDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.ProductService.CreateAsync(userId, productForCreationDto, cancellationToken);
		return Ok();
	}

	[HttpPut("{productId:guid}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> UpdateAsync(Guid productId, [FromBody] ProductDto productForUpdateDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.ProductService.UpdateAsync(userId, productId, productForUpdateDto, cancellationToken);
		return Ok();
	}


	[HttpPut("{productId:guid}/options/{optionId:guid}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> AdjustOptionQuantityAsync(Guid productId, Guid optionId, int count, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.ProductService.AdjustOptionQuantityAsync(userId, optionId, productId, count, cancellationToken);
		return Ok();
	}

	[HttpDelete("{productId:guid}/option/{optionId:Guid?}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> DeleteProductOrOptionAsync(Guid productId, CancellationToken cancellationToken, Guid? optionId = null)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.ProductService.DeleteAsync(userId, productId, optionId, cancellationToken);
		return Ok();
	}
}