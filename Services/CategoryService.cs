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


	public async Task<IEnumerable<CategoriesListResponse>> GetAllCategoriesListAsync(CancellationToken cancellationToken = default)
	{
		IEnumerable<CategoryEntity> categories = await _repositoryManager.CategoryRepository.GetAllAsync(cancellationToken);
		var categoryResponse = categories.Adapt<IEnumerable<CategoriesListResponse>>();
		return categoryResponse;
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

	public async Task<CategoryManagementResponse> GetManagementByIdAsync(int categoryId, CancellationToken cancellationToken = default)
	{
		CategoryEntity category = await _repositoryManager.CategoryRepository.GetManagementById(categoryId, cancellationToken);
		var categoryResponse = category.Adapt<CategoryManagementResponse>();
		return categoryResponse;
	}

	public async Task DeleteAsync(string userId, int categoryId,
		CancellationToken cancellationToken = default)
	{
		CategoryEntity category = await _repositoryManager.CategoryRepository.GetCategoryAndSubCategoryAsync(categoryId, cancellationToken);
		_repositoryManager.CategoryRepository.Delete(category);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task DeleteSubCategoryAsync(string userId, int categoryId, int? subcategoryid, CancellationToken cancellationToken)
	{
		CategoryEntity category = await _repositoryManager.CategoryRepository.GetCategoryAndSubCategoryAsync(categoryId, cancellationToken);
		if (category.SubCategories == null)
			throw new Exception("No subcategories found");
		if (subcategoryid != null)
		{
			SubCategoryEntity? subCategory = category.SubCategories.FirstOrDefault(x => x.Id == subcategoryid);
			if (subCategory == null)
				throw new Exception("No subcategory found");
			category.SubCategories.Remove(subCategory);
		}
		else
		{
			category.SubCategories.Clear();
		}
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task CreateAsync(string userId, CategoryDto categoryDto, CancellationToken cancellationToken = default)
	{
		var category = new CategoryEntity();
		category = categoryDto.Adapt(category);
		if (categoryDto.SubCategories != null)
			category.SubCategories = categoryDto.SubCategories.Adapt<List<SubCategoryEntity>>();

		_repositoryManager.CategoryRepository.Insert(category);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task UpdateAsync(string userId, int categoryId, CategoryDto categoryUpdateDto, CancellationToken cancellationToken = default)
	{
		CategoryEntity category = await _repositoryManager.CategoryRepository.GetByIdAsync(categoryId, cancellationToken);
		category = categoryUpdateDto.Adapt(category);
		_repositoryManager.CategoryRepository.Update(category);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task<IEnumerable<SubCategoriesListResponse>> GetSubCategoriesListAsync(int categoryId, CancellationToken cancellationToken = default)
	{
		IEnumerable<SubCategoryEntity> subCategories = await _repositoryManager.CategoryRepository.GetSubCategoriesListAsync(categoryId, cancellationToken);
		var subCategoryResponse = subCategories.Adapt<IEnumerable<SubCategoriesListResponse>>();
		return subCategoryResponse;
	}
}