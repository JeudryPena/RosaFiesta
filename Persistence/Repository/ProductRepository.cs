using Domain.Entities;
using Domain.IRepository;

namespace Persistence.Repository;

public class ProductRepository: IProductRepository
{
    private readonly RosaFiestaContext _dbContext;
    
    public ProductRepository(RosaFiestaContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Insert(ProductEntity product)
    {
        _dbContext.Products.Add(product);
    }
}