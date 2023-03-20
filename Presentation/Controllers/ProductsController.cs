using Contracts.Model;
using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController: ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public ProductsController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProductsPreview(CancellationToken cancellationToken)
    {
        ICollection<ProductPreviewResponse> products = await _serviceManager.ProductService.GetAllAsyncPreview(cancellationToken);
        return Ok(products);
    }
    
    [HttpGet("{productCode}/productDetail")]
    public async Task<IActionResult> GetProductDetail(string productCode, CancellationToken cancellationToken)
    {
        ProductDetailResponse product = await _serviceManager.ProductService.GetProductDetail(productCode, cancellationToken);
        return Ok(product);
    }
    
    [HttpGet("{productId}")]
    public async Task<IActionResult> GetProductById(string productId, CancellationToken cancellationToken)
    {
        ProductsResponse product = await _serviceManager.ProductService.GetByIdAsync(productId, cancellationToken);
        return Ok(product);
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDto productForCreationDto, CancellationToken cancellationToken)
    {
        string? username = User.Identity?.Name;
        ProductsResponse productDto = await _serviceManager.ProductService.CreateAsync(username, productForCreationDto, cancellationToken);
        return Ok(productDto);
    }
    
    [HttpPut("{productId}")]
    [Authorize]
    public async Task<IActionResult> UpdateProduct(string productId, [FromBody] ProductUpdateDto productForUpdateDto, CancellationToken cancellationToken)
    {
        string? username = User.Identity?.Name;
        ProductsResponse products = await _serviceManager.ProductService.UpdateAsync(username, productId, productForUpdateDto, cancellationToken);
        return Ok(products);
    }
    
    [HttpDelete("{productId}")]
    [Authorize]
    public async Task<IActionResult> DeleteProduct(string productId, CancellationToken cancellationToken)
    {
        await _serviceManager.ProductService.DeleteAsync(productId, cancellationToken);
        return Ok();
    }
    
    [HttpPatch("{productId}")]
    [Authorize]
    public async Task<IActionResult> AdjustProductQuantity(string productId, int count, CancellationToken cancellationToken)
    {
        string? username = User.Identity?.Name;
        ProductAdjustResponse products = await _serviceManager.ProductService.AdjustProductQuantityAsync(username, productId, count, cancellationToken);
        return Ok(products);
    }
}