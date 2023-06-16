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

	public async Task<IEnumerable<CategoryEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
		await _rosaFiestaContext.Categories.Include(x => x.SubCategories.Where(x => x.IsDeleted == false)).Where(x => x.IsDeleted == false).ToListAsync(cancellationToken);

	public void Insert(CategoryEntity category) =>
	_rosaFiestaContext.Categories.Add(category);

	public async Task<CategoryEntity> GetByIdAsync(int categoryId, CancellationToken cancellationToken = default)
	{
		var category = await _rosaFiestaContext.Categories.Include(x => x.Products.Where(x => x.IsDeleted == false))
			.FirstOrDefaultAsync(x => x.Id == categoryId, cancellationToken);
		if (category == null)
			throw new ArgumentNullException(nameof(category));
		if (category.IsDeleted)
			throw new InvalidOperationException("The category is deleted");
		return category;
	}

	public async Task<CategoryEntity> GetManagementById(int categoryId, CancellationToken cancellationToken = default)
	{
		var category = await _rosaFiestaContext.Categories.Include(x => x.SubCategories.Where(x => x.IsDeleted == false))
			.FirstOrDefaultAsync(x => x.Id == categoryId, cancellationToken);
		if (category == null)
			throw new ArgumentNullException(nameof(category));
		if (category.IsDeleted)
			throw new InvalidOperationException("The category is deleted");
		return category;
	}

	public void Update(CategoryEntity category)
	{
		_rosaFiestaContext.Categories.Update(category);
	}

	public async Task<CategoryEntity> GetCategoryAndSubCategoryAsync(int categoryId, CancellationToken cancellationToken)
	{
		var category = await _rosaFiestaContext.Categories
			.FirstOrDefaultAsync(x => x.Id == categoryId, cancellationToken);
		if (category == null)
			throw new ArgumentNullException(nameof(category), "Category not found");
		if (category.IsDeleted)
			throw new InvalidOperationException("The category is deleted");
		return category;
	}

	public void UpdateSubCategory(SubCategoryEntity subCategory)
	=> _rosaFiestaContext.SubCategories.Update(subCategory);
}