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
    
    [HttpPost("{productId}/option")]
    [Authorize]
    public async Task<IActionResult> CreateOption(string productId, [FromBody] OptionDto optionForCreationDto, CancellationToken cancellationToken)
    {
        string? username = User.Identity?.Name;
        OptionResponse option = await _serviceManager.ProductService.CreateOptionAsync(username, productId, optionForCreationDto, cancellationToken);
        return Ok(option);
    }
    
    [HttpPut("{productId}")]
    [Authorize]
    public async Task<IActionResult> UpdateProduct(string productId, [FromBody] ProductUpdateDto productForUpdateDto, CancellationToken cancellationToken)
    {
        string? username = User.Identity?.Name;
        ProductsResponse products = await _serviceManager.ProductService.UpdateAsync(username, productId, productForUpdateDto, cancellationToken);
        return Ok(products);
    }
    
    [HttpPut("{productId}/option/{optionId}")]
    [Authorize]
    public async Task<IActionResult> UpdateOption(string productId, int optionId, [FromBody] OptionUpdateDto optionForCreationDto, CancellationToken cancellationToken)
    {
        string? username = User.Identity?.Name;
        OptionResponse option = await _serviceManager.ProductService.UpdateOptionAsync(username, optionId, productId, optionForCreationDto, cancellationToken);
        return Ok(option);
    }

    [HttpPut("{productId}/options/{optionId}")]
    [Authorize]
    public async Task<IActionResult> AdjustOptionQuantity(string productId, int optionId, int count, CancellationToken cancellationToken)
    {
        string? username = User.Identity?.Name;
        OptionAdjustResponse products = await _serviceManager.ProductService.AdjustOptionQuantityAsync(username, optionId, productId, count, cancellationToken);
        return Ok(products);
    }
    
    [HttpPut("{productId}")]
    [Authorize]
    public async Task<IActionResult> AdjustProductQuantity(string productId, int count, CancellationToken cancellationToken)
    {
        string? username = User.Identity?.Name;
        ProductAdjustResponse products = await _serviceManager.ProductService.AdjustProductQuantityAsync(username, productId, count, cancellationToken);
        return Ok(products);
    }
    
    [HttpDelete("{productId}")]
    [Authorize]
    public async Task<IActionResult> DeleteProduct(string productId, CancellationToken cancellationToken)
    {
        await _serviceManager.ProductService.DeleteAsync(productId, cancellationToken);
        return Ok();
    }
    
    [HttpDelete("{productId}/option/{optionId}")]
    [Authorize]
    public async Task<IActionResult> DeleteOption(string productId, int optionId, CancellationToken cancellationToken)
    {
        await _serviceManager.ProductService.DeleteOptionAsync(productId, optionId, cancellationToken);
        return Ok();
    }
    
    [HttpDelete("{productId}/options")]
    [Authorize]
    public async Task<IActionResult> DeleteAllProductOptions(string productId, CancellationToken cancellationToken)
    {
        await _serviceManager.ProductService.DeleteOptionsAsync(productId, cancellationToken);
        return Ok();
    }
}