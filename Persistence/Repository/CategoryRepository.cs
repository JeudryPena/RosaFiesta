using Domain.Entities.Product;
using Domain.IRepository;

using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

public class CategoryRepository : ICategoryRepository
{
	private readonly RosaFiestaContext _rosaFiestaContext;

	public CategoryRepository(RosaFiestaContext rosaFiestaContext)
	{
		_rosaFiestaContext = rosaFiestaContext;
	}

	public async Task<IEnumerable<SubCategoryEntity>> GetSubCategoriesListAsync(int categoryId, CancellationToken cancellationToken = default)
	{
		var category = await _rosaFiestaContext.Categories.Include(x => x.SubCategories)
			.FirstOrDefaultAsync(x => x.Id == categoryId, cancellationToken);
		if (category == null)
			throw new ArgumentNullException(nameof(category));
		if (category.SubCategories == null)
			return category.SubCategories = new List<SubCategoryEntity>();
		return category.SubCategories;
	}

	public async Task<IEnumerable<CategoryEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
		await _rosaFiestaContext.Categories.Include(x => x.SubCategories).ToListAsync(cancellationToken);

	public void Insert(CategoryEntity category) =>
	_rosaFiestaContext.Categories.Add(category);

	public async Task<CategoryEntity> GetByIdAsync(int categoryId, CancellationToken cancellationToken = default)
	{
		var category = await _rosaFiestaContext.Categories.Include(x => x.SubCategories).Include(x => x.Products)
			.FirstOrDefaultAsync(x => x.Id == categoryId, cancellationToken);
		if (category == null)
			throw new ArgumentNullException(nameof(category));
		return category;
	}

	public async Task<CategoryEntity> GetManagementById(int categoryId, CancellationToken cancellationToken = default)
	{
		var category = await _rosaFiestaContext.Categories.Include(x => x.SubCategories)
			.FirstOrDefaultAsync(x => x.Id == categoryId, cancellationToken);
		if (category == null)
			throw new ArgumentNullException(nameof(category));
		return category;
	}

	public void Update(CategoryEntity category)
	=> _rosaFiestaContext.Categories.Update(category);


	public async Task<CategoryEntity> GetCategoryAndSubCategoryAsync(int categoryId, CancellationToken cancellationToken)
	{
		var category = await _rosaFiestaContext.Categories.Include(x => x.SubCategories)
			.FirstOrDefaultAsync(x => x.Id == categoryId, cancellationToken);
		if (category == null)
			throw new ArgumentNullException(nameof(category), "Category not found");
		return category;
	}

	public void UpdateSubCategory(SubCategoryEntity subCategory)
	=> _rosaFiestaContext.SubCategories.Update(subCategory);

	public void Delete(CategoryEntity category)
	=> _rosaFiestaContext.Categories.Remove(category);

	public void DeleteSubCategory(SubCategoryEntity subCategory)
		=> _rosaFiestaContext.SubCategories.Remove(subCategory);

}