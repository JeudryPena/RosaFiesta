using System.Net;
using System.Security.Claims;
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
    
    [HttpGet("options")]
    public async Task<IActionResult> GetProductsPreview(CancellationToken cancellationToken)
    {
        ICollection<ProductAndOptionsPreviewResponse> options = await _serviceManager.ProductService.GetAllAsyncPreview(cancellationToken);
        return Ok(options);
    }
    
    [HttpGet("{productCode}/option/{optionId}/productDetail")]
    [Authorize]
    public async Task<IActionResult> GetProductDetail(string productCode, int optionId, CancellationToken cancellationToken)
    {
        ProductAndOptionDetailResponse productAndOption = await _serviceManager.ProductService.GetProductDetail(productCode, optionId, cancellationToken);
        return Ok(productAndOption);
    }

    [HttpGet("{productCode}/option/{optionId}")]
    public async Task<IActionResult> GetProductById(string productCode, int optionId, CancellationToken cancellationToken)
    {
        ProductAndOptionResponse productAndOption = await _serviceManager.ProductService.GetByIdAsync(productCode, optionId, cancellationToken);
        return Ok(productAndOption);
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDto productForCreationDto, CancellationToken cancellationToken)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        ProductAndOptionResponse productAndOptionDto = await _serviceManager.ProductService.CreateAsync(userId, productForCreationDto, cancellationToken);
        return Ok(productAndOptionDto);
    }
    
    [HttpPost("{productId}/option")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateOption(string productId, [FromBody] OptionDto optionForCreationDto, CancellationToken cancellationToken)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        ProductAndOptionResponse option = await _serviceManager.ProductService.CreateOptionAsync(userId, productId, optionForCreationDto, cancellationToken);
        return Ok(option);
    }
    
    [HttpPut("{productId}/option/{optionId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateProduct(string productId, int optionId, [FromBody] ProductUpdateDto productForUpdateDto, CancellationToken cancellationToken)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        ProductAndOptionResponse productAndOption = await _serviceManager.ProductService.UpdateAsync(userId, optionId, productId, productForUpdateDto, cancellationToken);
        return Ok(productAndOption);
    }
    

    [HttpPut("{productId}/options/{optionId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AdjustOptionQuantity(string productId, int optionId, int count, CancellationToken cancellationToken)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        OptionAdjustResponse products = await _serviceManager.ProductService.AdjustOptionQuantityAsync(userId, optionId, productId, count, cancellationToken);
        return Ok(products);
    }
    
    [HttpDelete("{productId}/option/{optionId?}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteProductOrOption(string productId, CancellationToken cancellationToken, int? optionId = 0)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        if (optionId != 0)
            optionId = null;
        await _serviceManager.ProductService.DeleteAsync(userId, productId, optionId, cancellationToken);
        return Ok();
    }
}