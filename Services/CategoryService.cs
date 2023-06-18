using Contracts.Model.Product;
using Contracts.Model.Product.Response;

using Domain.Entities.Product;
using Domain.IRepository;

using Mapster;

using Services.Abstractions;

namespace Services;

internal sealed class CategoryService : ICategoryService
{
	private readonly IRepositoryManager _repositoryManager;
	public CategoryService(IRepositoryManager repositoryManager)
	{
		_repositoryManager = repositoryManager;
	}

	public async Task<IEnumerable<CategoryManagementResponse>> GetAllCategoriesManagementAsync(CancellationToken cancellationToken = default)
	{
		IEnumerable<CategoryEntity> categories = await _repositoryManager.CategoryRepository.GetAllAsync(cancellationToken);
		var categoryResponse = categories.Adapt<IEnumerable<CategoryManagementResponse>>();
		return categoryResponse;
	}

	public async Task<IEnumerable<CategoryPreviewResponse>> GetAllCategoriesPreviewAsync(CancellationToken cancellationToken = default)
	{
		IEnumerable<CategoryEntity> categories = await _repositoryManager.CategoryRepository.GetAllAsync(cancellationToken);
		var categoryResponse = categories.Adapt<IEnumerable<CategoryPreviewResponse>>();
		return categoryResponse;
	}

	public async Task<IEnumerable<CategoryResponse>> GetAllAsync(CancellationToken cancellationToken = default)
	{
		IEnumerable<CategoryEntity> categories = await _repositoryManager.CategoryRepository.GetAllAsync(cancellationToken);
		var categoryResponse = categories.Adapt<IEnumerable<CategoryResponse>>();
		return categoryResponse;
	}

	public async Task<CategoryResponse> GetByIdAsync(int categoryId, CancellationToken cancellationToken = default)
	{
		CategoryEntity category = await _repositoryManager.CategoryRepository.GetByIdAsync(categoryId, cancellationToken);
		var categoryResponse = category.Adapt<CategoryResponse>();
		return categoryResponse;
	}

	public async Task<CategoryPreviewResponse> GetManagementByIdAsync(int categoryId, CancellationToken cancellationToken = default)
	{
		CategoryEntity category = await _repositoryManager.CategoryRepository.GetManagementById(categoryId, cancellationToken);
		var categoryResponse = category.Adapt<CategoryPreviewResponse>();
		return categoryResponse;
	}

	public async Task DeleteAsync(string userId, int categoryId,
		CancellationToken cancellationToken = default)
	{
		CategoryEntity category = await _repositoryManager.CategoryRepository.GetCategoryAndSubCategoryAsync(categoryId, cancellationToken);
		category.IsDeleted = true;
		category.UpdatedBy = userId;
		category.UpdatedAt = DateTimeOffset.UtcNow;
		_repositoryManager.CategoryRepository.Update(category);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
	}

	public async Task DeleteSubCategoryAsync(string userId, int categoryId, int subcategoryid, CancellationToken cancellationToken)
	{
		CategoryEntity category = await _repositoryManager.CategoryRepository.GetCategoryAndSubCategoryAsync(categoryId, cancellationToken);
		category.UpdatedBy = userId;
		category.UpdatedAt = DateTimeOffset.UtcNow;
		SubCategoryEntity subCategory = category.SubCategories.FirstOrDefault(x => x.Id == subcategoryid);
		subCategory.IsDeleted = true;
		_repositoryManager.CategoryRepository.UpdateSubCategory(subCategory);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
	}

	public async Task CreateAsync(string userId, CategoryDto categoryDto, CancellationToken cancellationToken = default)
	{
		var category = new CategoryEntity();
		category = categoryDto.Adapt(category);
		category.CreatedBy = userId;
		if (categoryDto.SubCategories != null)
			category.SubCategories = categoryDto.SubCategories.Adapt<List<SubCategoryEntity>>();

		_repositoryManager.CategoryRepository.Insert(category);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
	}

	public async Task UpdateAsync(string userId, int categoryId, CategoryDto categoryUpdateDto, CancellationToken cancellationToken = default)
	{
		CategoryEntity category = await _repositoryManager.CategoryRepository.GetByIdAsync(categoryId, cancellationToken);
		category = categoryUpdateDto.Adapt(category);
		category.UpdatedAt = DateTimeOffset.UtcNow;
		category.UpdatedBy = userId;

		_repositoryManager.CategoryRepository.Update(category);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
	}
}