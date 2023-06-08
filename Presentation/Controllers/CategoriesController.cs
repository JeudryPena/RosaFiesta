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

	[HttpGet("categoriesPreview")]
	public async Task<IActionResult> GetCategoriesPreview(CancellationToken cancellationToken)
	{
		IEnumerable<CategoryPreviewResponse> categories = await _serviceManager.CategoryService.GetAllCategoriesPreviewAsync(cancellationToken);
		return Ok(categories);
	}

	[HttpGet("categoriesManagement")]
	public async Task<IActionResult> GetCategoriesManagement(CancellationToken cancellationToken)
	{
		IEnumerable<CategoryManagementResponse> products = await _serviceManager.CategoryService.GetAllManagementAsync(cancellationToken);
		return Ok(products);
	}

	[HttpGet]
	public async Task<IActionResult> GetCategories(CancellationToken cancellationToken)
	{
		IEnumerable<CategoryResponse> products = await _serviceManager.CategoryService.GetAllAsync(cancellationToken);
		return Ok(products);
	}

	[HttpGet("sub-category")]
	public async Task<IActionResult> GetSubCategories(CancellationToken cancellationToken)
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
	public async Task<IActionResult> GetSubCategoryByCategoryId(int categoryId, int subCategoryId, CancellationToken cancellationToken)
	{
		SubCategoryResponse products = await _serviceManager.CategoryService.GetSubCategoryByIdAsync(categoryId, subCategoryId, cancellationToken);
		return Ok(products);
	}

	[HttpPost]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> CreateCategory([FromBody] CategoryDto categoryDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		CategoryResponse categoryResponse = await _serviceManager.CategoryService.CreateAsync(userId, categoryDto, cancellationToken);
		return Ok(categoryResponse);
	}

	[HttpPost("sub-category")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> CreateSubCategory([FromBody] List<SubCategoryDto> subCategoryDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		List<SubCategoryResponse> subCategoryResponse = await _serviceManager.CategoryService.CreateSubCategoryAsync(userId, subCategoryDto, cancellationToken);
		return Ok(subCategoryResponse);
	}

	[HttpPut("{categoryId}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> UpdateCategory(int categoryId, [FromBody] CategoryUpdateDto categoryUpdateDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		CategoryResponse categoryResponse = await _serviceManager.CategoryService.UpdateAsync(userId, categoryId, categoryUpdateDto, cancellationToken);
		return Ok(categoryResponse);
	}

	[HttpPut("{categoryId}/sub-category/{subCategoryId}")]
	[Authorize]
	public async Task<IActionResult> UpdateSubCategory(int categoryId, int subCategoryId, [FromBody] SubCategoryUpdateDto subCategoryUpdateDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		SubCategoryResponse subCategoryResponse = await _serviceManager.CategoryService.UpdateSubCategoryAsync(userId, categoryId, subCategoryId, subCategoryUpdateDto, cancellationToken);
		return Ok(subCategoryResponse);
	}

	[HttpPut("move")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> MoveSubCategories(List<MoveSubCategoryDto> moveSubCategoryDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		List<SubCategoryResponse> subCategoryResponse = await _serviceManager.CategoryService.MoveSubCategoriesAsync(userId, moveSubCategoryDto, cancellationToken);
		return Ok(subCategoryResponse);
	}

	[HttpPut("drag")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> DragSubCategory(MoveSubCategoryDto moveSubCategoryDto, CancellationToken cancellationToken)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		SubCategoryResponse subCategoryResponse = await _serviceManager.CategoryService.DragSubCategory(userId, moveSubCategoryDto, cancellationToken);
		return Ok(subCategoryResponse);
	}

	[HttpGet("{categoryId}/sub-category/{subCategoryId?}/delete")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> DeleteCategory(int categoryId, CancellationToken cancellationToken, int? subCategoryId = 0)
	{
		string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (userId == null)
			return StatusCode((int)HttpStatusCode.Unauthorized);
		if (subCategoryId != 0)
			subCategoryId = null;
		await _serviceManager.CategoryService.DeleteAsync(userId, categoryId, subCategoryId, cancellationToken);
		return Ok();
	}
}