using Domain.Entities.Product;
using Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

public class CategoryRepository: ICategoryRepository
{
    private readonly RosaFiestaContext _rosaFiestaContext;
    
    public CategoryRepository(RosaFiestaContext rosaFiestaContext)
    {
        _rosaFiestaContext = rosaFiestaContext;
    }

    public async Task<IEnumerable<CategoryEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _rosaFiestaContext.Categories.Include(x => x.SubCategories).Include(x => x.Products).ToListAsync(cancellationToken);

    public void Insert(CategoryEntity category)
    {
        _rosaFiestaContext.Categories.AddAsync(category);
    }
}