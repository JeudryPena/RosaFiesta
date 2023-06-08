using Contracts.Model.Product;
using Contracts.Model.Product.Response;

using Domain.Entities.Product;
using Domain.Entities.Security;
using Domain.Entities.Security.Helper;
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

	public async Task<IEnumerable<CategoryManagementResponse>> GetAllManagementAsync(CancellationToken cancellationToken)
	{
		IEnumerable<CategoryEntity> categories = await _repositoryManager.CategoryRepository.GetAllManagementAsync(cancellationToken);
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

	public async Task<IEnumerable<SubCategoryResponse>> GetAllSubCategoriesAsync(CancellationToken cancellationToken = default)
	{
		IEnumerable<SubCategoryEntity> subCategories = await _repositoryManager.CategoryRepository.GetAllSubCategoriesAsync(cancellationToken);
		var subCategoryResponse = subCategories.Adapt<IEnumerable<SubCategoryResponse>>();
		return subCategoryResponse;
	}

	public async Task<SubCategoryResponse> GetSubCategoryByIdAsync(int categoryId, int subCategoryId, CancellationToken cancellationToken = default)
	{
		SubCategoryEntity subCategory = await _repositoryManager.CategoryRepository.GetSubCategoryByIdAsync(categoryId, subCategoryId, cancellationToken);
		var subCategoryResponse = subCategory.Adapt<SubCategoryResponse>();
		return subCategoryResponse;
	}

	public async Task<CategoryResponse> GetByIdAsync(int categoryId, CancellationToken cancellationToken = default)
	{
		CategoryEntity category = await _repositoryManager.CategoryRepository.GetByIdAsync(categoryId, cancellationToken);
		if (category.IsDeleted == true)
			throw new("Category not found");
		var categoryResponse = category.Adapt<CategoryResponse>();
		return categoryResponse;
	}

	public async Task DeleteAsync(string userId, int categoryId, int? subCategoryId,
		CancellationToken cancellationToken = default)
	{
		ActionLogEntity actionLog = new()
		{
			UserId = userId,
			ActivityType = Activities.Subcategory,
			Action = ActivityAction.Deleted,
		};
		if (subCategoryId == null)
		{
			CategoryEntity category = await _repositoryManager.CategoryRepository.GetCategoryAndSubCategoryAsync(categoryId, cancellationToken);
			category.IsDeleted = true;
			_repositoryManager.CategoryRepository.Update(category);
			actionLog.ActivityType = Activities.Category;
		}
		else
		{
			SubCategoryEntity subCategory = await _repositoryManager.CategoryRepository.GetSubCategoryByIdAsync(categoryId, subCategoryId.Value, cancellationToken);
			subCategory.IsDeleted = true;
			_repositoryManager.CategoryRepository.UpdateSubCategory(subCategory);
			actionLog.ActivityType = Activities.Subcategory;
		}
		_repositoryManager.ActionLogRepository.Create(actionLog);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
	}

	public async Task<CategoryResponse> CreateAsync(string userId, CategoryDto categoryDto, CancellationToken cancellationToken = default)
	{
		var category = new CategoryEntity
		{
			Name = categoryDto.Name,
			Description = categoryDto.Description,
			Icon = categoryDto.Icon,
		};
		if (categoryDto.SubCategories != null)
		{
			category.SubCategories = categoryDto.SubCategories.Adapt<List<SubCategoryEntity>>();
		}
		ActionLogEntity actionLog = new()
		{
			UserId = userId,
			ActivityType = Activities.Category,
			Action = ActivityAction.Created,
			ActivityId = category.Id.ToString(),
		};
		_repositoryManager.ActionLogRepository.Create(actionLog);
		_repositoryManager.CategoryRepository.Insert(category);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
		CategoryResponse categoryResponse = category.Adapt<CategoryResponse>();
		return categoryResponse;
	}

	public async Task<List<SubCategoryResponse>> CreateSubCategoryAsync(string userId, List<SubCategoryDto> subCategoryDto,
		CancellationToken cancellationToken = default)
	{
		List<SubCategoryEntity> subCategory = subCategoryDto.Adapt<List<SubCategoryEntity>>();
		_repositoryManager.CategoryRepository.InsertSubCategory(subCategory);
		ActionLogEntity actionLog = new()
		{
			UserId = userId,
			ActivityType = Activities.Subcategory,
			Action = ActivityAction.Created,
			ActivityId = subCategory.FirstOrDefault().Id.ToString(),
		};
		_repositoryManager.ActionLogRepository.Create(actionLog);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
		List<SubCategoryResponse> subCategoryResponse = subCategory.Adapt<List<SubCategoryResponse>>();
		return subCategoryResponse;
	}

	public async Task<CategoryResponse> UpdateAsync(string userId, int categoryId, CategoryUpdateDto categoryUpdateDto, CancellationToken cancellationToken = default)
	{
		CategoryEntity category = await _repositoryManager.CategoryRepository.GetByIdAsync(categoryId, cancellationToken);
		category.Name = categoryUpdateDto.Name;
		category.Description = categoryUpdateDto.Description;
		category.Icon = categoryUpdateDto.Icon;
		_repositoryManager.CategoryRepository.Update(category);
		ActionLogEntity actionLog = new()
		{
			UserId = userId,
			ActivityType = Activities.Category,
			Action = ActivityAction.Updated,
		};
		_repositoryManager.ActionLogRepository.Create(actionLog);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
		CategoryResponse categoryResponse = category.Adapt<CategoryResponse>();
		return categoryResponse;
	}

	public async Task<SubCategoryResponse> UpdateSubCategoryAsync(string userId, int categoryId, int subCategoryId, SubCategoryUpdateDto subCategoryUpdateDto, CancellationToken cancellationToken = default)
	{
		SubCategoryEntity subCategory = await _repositoryManager.CategoryRepository.GetSubCategoryByIdAsync(categoryId, subCategoryId, cancellationToken);
		subCategory.Name = subCategoryUpdateDto.Name;
		subCategory.Description = subCategoryUpdateDto.Description;
		subCategory.Icon = subCategoryUpdateDto.Icon;
		_repositoryManager.CategoryRepository.UpdateSubCategory(subCategory);
		ActionLogEntity actionLog = new()
		{
			UserId = userId,
			ActivityType = Activities.Subcategory,
			Action = ActivityAction.Updated,
		};
		_repositoryManager.ActionLogRepository.Create(actionLog);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
		SubCategoryResponse subCategoryResponse = subCategory.Adapt<SubCategoryResponse>();
		return subCategoryResponse;
	}

	public async Task<List<SubCategoryResponse>> MoveSubCategoriesAsync(string userId, List<MoveSubCategoryDto> moveSubCategoryDto, CancellationToken cancellationToken = default)
	{
		List<SubCategoryEntity> subCategories = await _repositoryManager.CategoryRepository.GetSubCategoriesByIdsAsync(moveSubCategoryDto.Select(x => x.SubCategoryId).ToList(), cancellationToken);
		foreach (var subCategory in subCategories)
		{
			subCategory.CategoryId = moveSubCategoryDto.FirstOrDefault(x => x.SubCategoryId == subCategory.Id)?.NewCategoryId ?? subCategory.CategoryId;
		}
		_repositoryManager.CategoryRepository.UpdateSubCategories(subCategories);
		ActionLogEntity actionLog = new()
		{
			UserId = userId,
			ActivityType = Activities.Subcategory,
			Action = ActivityAction.Updated,
		};
		_repositoryManager.ActionLogRepository.Create(actionLog);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
		List<SubCategoryResponse> subCategoryResponse = subCategories.Adapt<List<SubCategoryResponse>>();
		return subCategoryResponse;
	}

	public async Task<SubCategoryResponse> DragSubCategory(string userId, MoveSubCategoryDto moveSubCategoryDto,
		CancellationToken cancellationToken = default)
	{
		SubCategoryEntity subCategory = await _repositoryManager.CategoryRepository.GetSubCategoryByIdAsync(moveSubCategoryDto.CategoryId, moveSubCategoryDto.SubCategoryId, cancellationToken);
		subCategory.CategoryId = moveSubCategoryDto.NewCategoryId;
		_repositoryManager.CategoryRepository.UpdateSubCategory(subCategory);
		ActionLogEntity actionLog = new()
		{
			UserId = userId,
			ActivityType = Activities.Subcategory,
			Action = ActivityAction.Updated,
		};
		_repositoryManager.ActionLogRepository.Create(actionLog);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
		SubCategoryResponse subCategoryResponse = subCategory.Adapt<SubCategoryResponse>();
		return subCategoryResponse;
	}
}