using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface ICategoryService
{
    Task<IEnumerable<CategoryPreviewResponse>> GetAllCategoriesPreviewAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<CategoryResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CategoryResponse> CreateAsync(string userId, CategoryDto categoryDto, CancellationToken cancellationToken = default);
    Task<List<SubCategoryResponse>> CreateSubCategoryAsync(string userId, List<SubCategoryDto> subCategoryDto,
        CancellationToken cancellationToken = default);
    Task<IEnumerable<SubCategoryResponse>> GetAllSubCategoriesAsync(CancellationToken cancellationToken = default);
    Task<SubCategoryResponse> GetSubCategoryByIdAsync(int categoryId, int subCategoryId, CancellationToken cancellationToken = default);
    Task<CategoryResponse> GetByIdAsync(int categoryId, CancellationToken cancellationToken = default);
    Task DeleteAsync(string userId, int categoryId, int? subCategoryId, CancellationToken cancellationToken = default);
    Task<CategoryResponse> UpdateAsync(string userId, int categoryId, CategoryUpdateDto categoryUpdateDto, CancellationToken cancellationToken = default);
    Task<SubCategoryResponse> UpdateSubCategoryAsync(string userId, int categoryId, int subCategoryId, SubCategoryUpdateDto subCategoryUpdateDto, CancellationToken cancellationToken = default);
    Task<List<SubCategoryResponse>> MoveSubCategoriesAsync(string userId, List<MoveSubCategoryDto> moveSubCategoryDto, CancellationToken cancellationToken = default);
    Task<SubCategoryResponse> DragSubCategory(string userId, MoveSubCategoryDto moveSubCategoryDto, CancellationToken cancellationToken = default);
}