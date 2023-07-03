using Domain.Entities.Product;

namespace Domain.IRepository;

public interface ICategoryRepository
{
	Task<IEnumerable<CategoryEntity>> GetAllAsync(CancellationToken cancellationToken = default);
	void Insert(CategoryEntity category);
	Task<CategoryEntity> GetByIdAsync(int categoryId, CancellationToken cancellationToken = default);
	void Update(CategoryEntity category);
	Task<CategoryEntity> GetCategoryAndSubCategoryAsync(int categoryId, CancellationToken cancellationToken);
	Task<CategoryEntity> GetManagementById(int categoryId, CancellationToken cancellationToken = default);
	void UpdateSubCategory(SubCategoryEntity subCategory);
	void Delete(CategoryEntity category);
	void DeleteSubCategory(SubCategoryEntity subCategory);
	Task<IEnumerable<SubCategoryEntity>> GetSubCategoriesListAsync(int categoryId, CancellationToken cancellationToken = default);
}