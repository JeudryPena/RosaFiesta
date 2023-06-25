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
public class CategoriesController : ControllerBase
{
	private readonly IServiceManager _serviceManager;

	public CategoriesController(IServiceManager serviceManager)
	{
		_serviceManager = serviceManager;
	}

	[HttpGet("categoriesManagement")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> GetCategoriesManagement(CancellationToken cancellationToken)
	{
		IEnumerable<CategoryManagementResponse> categories = await _serviceManager.CategoryService.GetAllCategoriesManagementAsync(cancellationToken);
		return Ok(categories);
	}

	[HttpGet("categoriesPreview")]
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

	[HttpGet("{categoryId}")]
	public async Task<IActionResult> GetCategoryById(int categoryId, CancellationToken cancellationToken)
	{
		CategoryResponse products = await _serviceManager.CategoryService.GetByIdAsync(categoryId, cancellationToken);
		return Ok(products);
	}

	[HttpGet("{categoryId}/category-management")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> GetCategoryManagementById(int categoryId, CancellationToken cancellationToken)
	{
		CategoryManagementResponse products = await _serviceManager.CategoryService.GetManagementByIdAsync(categoryId, cancellationToken);
		return Ok(products);
	}

	[HttpPost]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> CreateCategory([FromBody] CategoryDto categoryDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.CategoryService.CreateAsync(userId, categoryDto, cancellationToken);
		return Ok();
	}

	[HttpPut("{categoryId}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> UpdateCategory(int categoryId, [FromBody] CategoryDto categoryUpdateDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.CategoryService.UpdateAsync(userId, categoryId, categoryUpdateDto, cancellationToken);
		return Ok();
	}

	[HttpDelete("{categoryId}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> DeleteCategory(int categoryId, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.CategoryService.DeleteAsync(userId, categoryId, cancellationToken);
		return Ok();
	}

	[HttpDelete("{categoryId}/sub-category/{subcategoryid}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> DeleteSubCategory(int categoryId, int subcategoryid, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		await _serviceManager.CategoryService.DeleteSubCategoryAsync(userId, categoryId, subcategoryid, cancellationToken);
		return Ok();
	}
}