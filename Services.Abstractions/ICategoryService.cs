using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface ICategoryService
{
	Task<IEnumerable<CategoryPreviewResponse>> GetAllCategoriesPreviewAsync(CancellationToken cancellationToken = default);
	Task<IEnumerable<CategoryResponse>> GetAllAsync(CancellationToken cancellationToken = default);
	Task CreateAsync(string userId, CategoryDto categoryDto, CancellationToken cancellationToken = default);
	Task<CategoryResponse> GetByIdAsync(int categoryId, CancellationToken cancellationToken = default);
	Task DeleteAsync(string userId, int categoryId, CancellationToken cancellationToken = default);
	Task UpdateAsync(string userId, int categoryId, CategoryDto categoryUpdateDto, CancellationToken cancellationToken = default);
	Task DeleteSubCategoryAsync(string userId, int categoryId, int? subcategoryid, CancellationToken cancellationToken = default);
	Task<CategoryManagementResponse> GetManagementByIdAsync(int categoryId, CancellationToken cancellationToken = default);
	Task<IEnumerable<CategoryManagementResponse>> GetAllCategoriesManagementAsync(CancellationToken cancellationToken = default);
	Task<IEnumerable<CategoriesListResponse>> GetAllCategoriesListAsync(CancellationToken cancellationToken = default);
	Task<IEnumerable<SubCategoriesListResponse>> GetSubCategoriesListAsync(int categoryId, CancellationToken cancellationToken = default);
}