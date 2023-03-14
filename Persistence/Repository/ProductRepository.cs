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

    public async Task<ProductEntity> GetByIdAsync(string productId, CancellationToken cancellationToken = default)
    {
        var product = await _dbContext.Products.Include(p => p.Category).Include(p => p.Supplier).Include(p => p.Warranty).FirstOrDefaultAsync(x => x.Code == productId, cancellationToken);
        if (product == null)
            throw new ArgumentNullException(nameof(product));
        return product;
    }

    public void Update(ProductEntity product) => _dbContext.Products.Update(product);
    public void Delete(ProductEntity product) => _dbContext.Products.Remove(product);

    public void Insert(ProductEntity product) => _dbContext.Products.Add(product);
}