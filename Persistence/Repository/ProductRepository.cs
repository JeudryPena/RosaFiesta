using Domain.Entities;
using Domain.Entities.Product;
using Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

public class ProductRepository: IProductRepository
{
    private readonly RosaFiestaContext _dbContext;
    
    public ProductRepository(RosaFiestaContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<ProductEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
    await _dbContext.Products.Include(p => p.Category).Include(p => p.Supplier).Include(p => p.Warranty).ToListAsync(cancellationToken);

    public void Insert(ProductEntity product) => _dbContext.Products.Add(product);
}