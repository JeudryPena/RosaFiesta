using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Domain.Entities.Product;
using Domain.IRepository;
using Mapster;
using Services.Abstractions;

namespace Services;

internal sealed class CategoryService: ICategoryService
{
    private readonly IRepositoryManager _repositoryManager;
    public CategoryService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
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
        var categoryResponse = category.Adapt<CategoryResponse>();
        return categoryResponse;
    }

    public async Task DeleteAsync(int categoryId, CancellationToken cancellationToken = default)
    {
        CategoryEntity category = await _repositoryManager.CategoryRepository.GetByIdAsync(categoryId, cancellationToken);
        _repositoryManager.CategoryRepository.Delete(category);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteSubCategoryAsync(int categoryId, int subCategoryId, CancellationToken cancellationToken = default)
    {
        SubCategoryEntity subCategory = await _repositoryManager.CategoryRepository.GetSubCategoryByIdAsync(categoryId, subCategoryId);
        _repositoryManager.CategoryRepository.DeleteSubCategory(subCategory);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<CategoryResponse> CreateAsync(string? username, CategoryDto categoryDto, CancellationToken cancellationToken = default)
    {
        var category = new CategoryEntity
        {
            Name = categoryDto.Name,
            Description = categoryDto.Description,
            CreatedAt = DateTimeOffset.UtcNow,
            CreatedBy = username,
            Icon = categoryDto.Icon,
            Slug = categoryDto.Slug,
            IsActive = categoryDto.IsActive,
        };
        if (categoryDto.SubCategories != null){
            category.SubCategories = categoryDto.SubCategories.Adapt<List<SubCategoryEntity>>();
            foreach (var subCategory in category.SubCategories)
            {
                subCategory.CreatedAt = DateTimeOffset.UtcNow;
                subCategory.CreatedBy = username;
            } 
        }
        
        _repositoryManager.CategoryRepository.Insert(category);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        CategoryResponse categoryResponse = category.Adapt<CategoryResponse>();
        return categoryResponse;
    }

    public async Task<List<SubCategoryResponse>> CreateSubCategoryAsync(string? username, List<SubCategoryDto> subCategoryDto,
        CancellationToken cancellationToken = default)
    {
        List<SubCategoryEntity> subCategory = subCategoryDto.Adapt<List<SubCategoryEntity>>();
        foreach (var x in subCategory)
        {
            x.CreatedAt = DateTimeOffset.UtcNow;
            x.CreatedBy = username;
        }
        _repositoryManager.CategoryRepository.InsertSubCategory(subCategory);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        List<SubCategoryResponse> subCategoryResponse = subCategory.Adapt<List<SubCategoryResponse>>();
        return subCategoryResponse;
    }
    
    public async Task<CategoryResponse> UpdateAsync(string? username, int categoryId, CategoryUpdateDto categoryUpdateDto, CancellationToken cancellationToken = default)
    {
        CategoryEntity category = await _repositoryManager.CategoryRepository.GetByIdAsync(categoryId, cancellationToken);
        category.Name = categoryUpdateDto.Name;
        category.Description = categoryUpdateDto.Description;
        category.Icon = categoryUpdateDto.Icon;
        category.Slug = categoryUpdateDto.Slug;
        category.IsActive = categoryUpdateDto.IsActive;
        category.UpdatedAt = DateTimeOffset.UtcNow;
        category.UpdatedBy = username;
        _repositoryManager.CategoryRepository.Update(category);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        CategoryResponse categoryResponse = category.Adapt<CategoryResponse>();
        return categoryResponse;
    }

    public async Task<SubCategoryResponse> UpdateSubCategoryAsync(string? username, int categoryId, int subCategoryId,
        SubCategoryUpdateDto subCategoryUpdateDto, CancellationToken cancellationToken = default)
    {
        SubCategoryEntity subCategory = await _repositoryManager.CategoryRepository.GetSubCategoryByIdAsync(categoryId, subCategoryId, cancellationToken);
        subCategory.Name = subCategoryUpdateDto.Name;
        subCategory.Description = subCategoryUpdateDto.Description;
        subCategory.Icon = subCategoryUpdateDto.Icon;
        subCategory.Slug = subCategoryUpdateDto.Slug;
        subCategory.IsActive = subCategoryUpdateDto.IsActive;
        subCategory.UpdatedAt = DateTimeOffset.UtcNow;
        subCategory.UpdatedBy = username;
        _repositoryManager.CategoryRepository.UpdateSubCategory(subCategory);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        SubCategoryResponse subCategoryResponse = subCategory.Adapt<SubCategoryResponse>();
        return subCategoryResponse;
    }

    public async Task<List<SubCategoryResponse>> MoveSubCategoriesAsync(string? username, List<MoveSubCategoryDto> moveSubCategoryDto, CancellationToken cancellationToken = default)
    {
        List<SubCategoryEntity> subCategories = await _repositoryManager.CategoryRepository.GetSubCategoriesByIdsAsync(moveSubCategoryDto.Select(x => x.SubCategoryId).ToList(), cancellationToken);
        foreach (var subCategory in subCategories)
        {
            subCategory.CategoryId = moveSubCategoryDto.FirstOrDefault(x => x.SubCategoryId == subCategory.Id)?.NewCategoryId ?? subCategory.CategoryId;
            subCategory.UpdatedAt = DateTimeOffset.UtcNow;
            subCategory.UpdatedBy = username;
        }
        _repositoryManager.CategoryRepository.UpdateSubCategories(subCategories);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        List<SubCategoryResponse> subCategoryResponse = subCategories.Adapt<List<SubCategoryResponse>>();
        return subCategoryResponse;
    }

    public async Task<SubCategoryResponse> DragSubCategory(string? username, MoveSubCategoryDto moveSubCategoryDto,
        CancellationToken cancellationToken = default)
    {
        SubCategoryEntity subCategory = await _repositoryManager.CategoryRepository.GetSubCategoryByIdAsync(moveSubCategoryDto.CategoryId, moveSubCategoryDto.SubCategoryId, cancellationToken);
        subCategory.CategoryId = moveSubCategoryDto.NewCategoryId;
        subCategory.UpdatedAt = DateTimeOffset.UtcNow;
        subCategory.UpdatedBy = username;
        _repositoryManager.CategoryRepository.UpdateSubCategory(subCategory);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        SubCategoryResponse subCategoryResponse = subCategory.Adapt<SubCategoryResponse>();
        return subCategoryResponse;
    }
}