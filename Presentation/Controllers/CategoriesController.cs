using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController: ControllerBase
{
    private readonly IServiceManager _serviceManager;
    
    public CategoryController( IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCategories(CancellationToken cancellationToken)
    {
        IEnumerable<CategoryResponse> products = await _serviceManager.CategoryService.GetAllAsync(cancellationToken);
        return Ok(products);
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryDto categoryDto, CancellationToken cancellationToken)
    {
        string? username = User.Identity?.Name;
        CategoryResponse categoryResponse = await _serviceManager.CategoryService.CreateAsync(username, categoryDto, cancellationToken);
        return Ok(categoryResponse);
    }
}