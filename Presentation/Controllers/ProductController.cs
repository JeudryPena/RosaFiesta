using Contracts.Model;
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
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductEntityDto productForCreationDto)
    {
        var productDto = await _serviceManager.ProductService.CreateAsync(productForCreationDto);
        return Ok(productDto);
    }
}