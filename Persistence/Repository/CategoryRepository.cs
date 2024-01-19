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
		await _rosaFiestaContext.Categories.ToListAsync(cancellationToken);

	public void Insert(CategoryEntity category) =>
	_rosaFiestaContext.Categories.Add(category);

	public async Task<CategoryEntity> GetByIdAsync(int categoryId, CancellationToken cancellationToken = default)
	{
		CategoryEntity? category = await _rosaFiestaContext.Categories.Include(x => x.Products).ThenInclude(x => x.Option).ThenInclude(x => x.Image).FirstOrDefaultAsync(x => x.Id == categoryId);
		if (category == null)
			throw new ArgumentNullException(nameof(category));
		return category;
	}

	public async Task<CategoryEntity> GetManagementById(int categoryId, CancellationToken cancellationToken = default)
	{
		var category = await _rosaFiestaContext.Categories
			.FirstOrDefaultAsync(x => x.Id == categoryId, cancellationToken);
		if (category == null)
			throw new ArgumentNullException(nameof(category));
		return category;
	}

	public void Update(CategoryEntity category)
	=> _rosaFiestaContext.Categories.Update(category);

	public void Delete(CategoryEntity category)
	=> _rosaFiestaContext.Categories.Remove(category);

	public async Task<string> GetCategoryNameByProductIdAsync(Guid productId, CancellationToken cancellationToken)
	{
		string name = await _rosaFiestaContext.Categories.Include(x => x.Products).FirstOrDefaultAsync(x => x.Products.Any(x => x.Id == productId), cancellationToken).ContinueWith( x => x.Result.Name, cancellationToken);
		return name;
	}
}