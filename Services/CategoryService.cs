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

	public async Task<string> GetCategoryNameByProductIdAsync(Guid productId, CancellationToken cancellationToken)
	{
		string name = await _repositoryManager.CategoryRepository.GetCategoryNameByProductIdAsync(productId, cancellationToken);
		return name;
	}

	public async Task<IEnumerable<CategoryManagementResponse>> GetAllCategoriesManagementAsync(CancellationToken cancellationToken = default)
	{
		IEnumerable<CategoryEntity> categories = await _repositoryManager.CategoryRepository.GetAllAsync(cancellationToken);
		foreach (var category in categories)
		{
			category.CreatedBy = await _repositoryManager.UserRepository.GetUserName(category.CreatedBy, cancellationToken);
			if (category.UpdatedBy != null)
				category.UpdatedBy = await _repositoryManager.UserRepository.GetUserName(category.UpdatedBy, cancellationToken);
		}
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
		categoryResponse.CreatedBy = await _repositoryManager.UserRepository.GetUserName(category.CreatedBy, cancellationToken);
		if (category.UpdatedBy != null)
			categoryResponse.UpdatedBy = await _repositoryManager.UserRepository.GetUserName(category.UpdatedBy, cancellationToken);
		return categoryResponse;
	}

	public async Task DeleteAsync(string userId, int categoryId,
		CancellationToken cancellationToken = default)
	{
		CategoryEntity category = await _repositoryManager.CategoryRepository.GetByIdAsync(categoryId, cancellationToken);
		_repositoryManager.CategoryRepository.Delete(category);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task CreateAsync(string userId, CategoryDto categoryDto, CancellationToken cancellationToken = default)
	{
		await _repositoryManager.CategoryRepository.CheckIfCategoryExistsAsync(categoryDto.Name, cancellationToken);
		var category = new CategoryEntity();
		category = categoryDto.Adapt(category);
		_repositoryManager.CategoryRepository.Insert(category);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task UpdateAsync(string userId, int categoryId, CategoryDto categoryUpdateDto, CancellationToken cancellationToken = default)
	{
		await _repositoryManager.CategoryRepository.CheckIfCategoryExistsAsync(categoryUpdateDto.Name, cancellationToken);
		CategoryEntity category = await _repositoryManager.CategoryRepository.GetByIdAsync(categoryId, cancellationToken);
		category = categoryUpdateDto.Adapt(category);
		_repositoryManager.CategoryRepository.Update(category);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}
}