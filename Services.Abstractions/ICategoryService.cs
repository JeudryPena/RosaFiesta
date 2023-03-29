using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface ICategoryService
{
    Task<IEnumerable<CategoryPreviewResponse>> GetAllCategoriesPreviewAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<CategoryResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CategoryResponse> CreateAsync(string? username, CategoryDto categoryDto, CancellationToken cancellationToken = default);
    Task<List<SubCategoryResponse>> CreateSubCategoryAsync(string? username, List<SubCategoryDto> subCategoryDto,
        CancellationToken cancellationToken = default);
    Task<IEnumerable<SubCategoryResponse>> GetAllSubCategoriesAsync(CancellationToken cancellationToken = default);
    Task<SubCategoryResponse> GetSubCategoryByIdAsync(int categoryId, int subCategoryId, CancellationToken cancellationToken = default);
    Task<CategoryResponse> GetByIdAsync(int categoryId, CancellationToken cancellationToken = default);
    Task DeleteAsync(int categoryId, CancellationToken cancellationToken = default);
    Task DeleteSubCategoryAsync(int categoryId, int subCategoryId, CancellationToken cancellationToken = default);
    Task<CategoryResponse> UpdateAsync(string? username, int categoryId, CategoryUpdateDto categoryUpdateDto, CancellationToken cancellationToken = default);
    Task<SubCategoryResponse> UpdateSubCategoryAsync(string? username, int categoryId, int subCategoryId, SubCategoryUpdateDto subCategoryUpdateDto, CancellationToken cancellationToken = default);
    Task<List<SubCategoryResponse>> MoveSubCategoriesAsync(string? username, List<MoveSubCategoryDto> moveSubCategoryDto, CancellationToken cancellationToken = default);
    Task<SubCategoryResponse> DragSubCategory(string? username, MoveSubCategoryDto moveSubCategoryDto, CancellationToken cancellationToken = default);
}