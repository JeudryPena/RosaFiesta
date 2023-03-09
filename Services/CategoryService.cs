using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Domain.Entities.Product;
using Domain.IRepository;
using Mapster;
using Services.Abstractions;

namespace Services;

public class CategoryService: ICategoryService
{
    private readonly IRepositoryManager _repositoryManager;
    public CategoryService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<IEnumerable<CategoryResponse>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<CategoryEntity> categories = await _repositoryManager.CategoryRepository.GetAllAsync(cancellationToken);
        var categoryResponse = categories.Adapt<IEnumerable<CategoryResponse>>();
        return categoryResponse;
    }

    public async Task<CategoryResponse> CreateAsync(string? username, CategoryDto categoryDto, CancellationToken cancellationToken = default)
    {
        var category = new CategoryEntity
        {
            Id = categoryDto.Id,
            Name = categoryDto.Name,
            Description = categoryDto.Description,
            CreatedAt = DateTimeOffset.UtcNow,
            CreatedBy = username,
            Icon = categoryDto.Icon,
            Slug = categoryDto.Slug,
            IsActive = categoryDto.IsActive,
        };
        if (category.SubCategories != null){
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
}