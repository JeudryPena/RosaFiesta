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
    
    [HttpGet("CategoriesPreview")]
    public async Task<IActionResult> GetCategoriesPreview(CancellationToken cancellationToken)
    {
        IEnumerable<CategoryPreviewResponse> categories = await _serviceManager.CategoryService.GetAllCategoriesPreviewAsync(cancellationToken);
        return Ok(categories);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCategories(CancellationToken cancellationToken)
    {
        IEnumerable<CategoryResponse> products = await _serviceManager.CategoryService.GetAllAsync(cancellationToken);
        return Ok(products);
    }
    
    [HttpGet("sub-category")]
    public async Task <IActionResult> GetSubCategories(CancellationToken cancellationToken)
    {
        IEnumerable<SubCategoryResponse> products = await _serviceManager.CategoryService.GetAllSubCategoriesAsync(cancellationToken);
        return Ok(products);
    }
    
    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetCategoriesById(int categoryId, CancellationToken cancellationToken)
    {
        CategoryResponse products = await _serviceManager.CategoryService.GetByIdAsync(categoryId, cancellationToken);
        return Ok(products);
    }
    
    [HttpGet("{categoryId}/sub-category/{subCategoryId}")]
    public async Task <IActionResult> GetSubCategoriesByCategoryId(int categoryId, int subCategoryId, CancellationToken cancellationToken)
    {
        SubCategoryResponse products = await _serviceManager.CategoryService.GetSubCategoryByIdAsync(categoryId, subCategoryId, cancellationToken);
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
    
    [HttpPost("sub-category")]
    [Authorize]
    public async Task<IActionResult> CreateSubCategory([FromBody] List<SubCategoryDto> subCategoryDto, CancellationToken cancellationToken)
    {
        string? username = User.Identity?.Name;
        List<SubCategoryResponse> subCategoryResponse = await _serviceManager.CategoryService.CreateSubCategoryAsync(username, subCategoryDto, cancellationToken);
        return Ok(subCategoryResponse);
    }
    
    [HttpPut("{categoryId}")]
    [Authorize]
    public async Task<IActionResult> UpdateCategory(int categoryId, [FromBody] CategoryUpdateDto categoryUpdateDto, CancellationToken cancellationToken)
    {
        string? username = User.Identity?.Name;
        CategoryResponse categoryResponse = await _serviceManager.CategoryService.UpdateAsync(username, categoryId, categoryUpdateDto, cancellationToken);
        return Ok(categoryResponse);
    }
    
    [HttpPut("{categoryId}/sub-category/{subCategoryId}")]
    [Authorize]
    public async Task<IActionResult> UpdateSubCategory(int categoryId, int subCategoryId, [FromBody] SubCategoryUpdateDto subCategoryUpdateDto, CancellationToken cancellationToken)
    {
        string? username = User.Identity?.Name;
        SubCategoryResponse subCategoryResponse = await _serviceManager.CategoryService.UpdateSubCategoryAsync(username, categoryId, subCategoryId, subCategoryUpdateDto, cancellationToken);
        return Ok(subCategoryResponse);
    }
    
    [HttpPut("move")]
    [Authorize]
    public async Task<IActionResult> MoveSubCategories(List<MoveSubCategoryDto> moveSubCategoryDto, CancellationToken cancellationToken)
    {
        string? username = User.Identity?.Name;
        List<SubCategoryResponse> subCategoryResponse = await _serviceManager.CategoryService.MoveSubCategoriesAsync(username, moveSubCategoryDto, cancellationToken);
        return Ok(subCategoryResponse);
    }
    
    [HttpPut("drag")]
    [Authorize]
    public async Task<IActionResult> DragSubCategory(MoveSubCategoryDto moveSubCategoryDto, CancellationToken cancellationToken)
    {
        string? username = User.Identity?.Name;
        SubCategoryResponse subCategoryResponse = await _serviceManager.CategoryService.DragSubCategory(username, moveSubCategoryDto, cancellationToken);
        return Ok(subCategoryResponse);
    }
    
    [HttpDelete("{categoryId}")]
    public async Task<IActionResult> DeleteCategory(int categoryId, CancellationToken cancellationToken)
    {
        await _serviceManager.CategoryService.DeleteAsync(categoryId, cancellationToken);
        return Ok();
    }
    
    [HttpDelete("{categoryId}/sub-category/{subCategoryId}")]
    public async Task<IActionResult> DeleteSubCategory(int categoryId, int subCategoryId, CancellationToken cancellationToken)
    {
        await _serviceManager.CategoryService.DeleteSubCategoryAsync(categoryId, subCategoryId, cancellationToken);
        return Ok();
    }
}