using Domain.Entities.Product;

namespace Domain.IRepository;

public interface ICategoryRepository
{
	Task<IEnumerable<CategoryEntity>> GetAllAsync(CancellationToken cancellationToken = default);
	Task<IEnumerable<SubCategoryEntity>> GetAllSubCategoriesAsync(CancellationToken cancellationToken = default);
	void Insert(CategoryEntity category);
	void InsertSubCategory(List<SubCategoryEntity> subCategory);
	Task<SubCategoryEntity> GetSubCategoryByIdAsync(int categoryId, int subCategoryId, CancellationToken cancellationToken = default);
	Task<CategoryEntity> GetByIdAsync(int categoryId, CancellationToken cancellationToken = default);
	void Update(CategoryEntity category);
	void UpdateSubCategory(SubCategoryEntity subCategory);
	Task<List<SubCategoryEntity>> GetSubCategoriesByIdsAsync(List<int> toList, CancellationToken cancellationToken = default);
	void UpdateSubCategories(List<SubCategoryEntity> subCategories);
	Task<CategoryEntity> GetCategoryAndSubCategoryAsync(int categoryId, CancellationToken cancellationToken);
}