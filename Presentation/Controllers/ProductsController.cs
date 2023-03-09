using Contracts.Model;
using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController: ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public ProductController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
    {
        IEnumerable<ProductsResponse> products = await _serviceManager.ProductService.GetAllAsync(cancellationToken);
        return Ok(products);
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateProduct([FromBody] ProductEntityDto productForCreationDto, CancellationToken cancellationToken)
    {
        string? username = User.Identity?.Name;
        ProductsResponse productDto = await _serviceManager.ProductService.CreateAsync(username, productForCreationDto, cancellationToken);
        return Ok(productDto);
    }
}