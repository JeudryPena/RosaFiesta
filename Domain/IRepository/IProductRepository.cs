using Domain.Entities;
using Domain.Entities.Product;

namespace Domain.IRepository;

public interface IProductRepository
{
    void Insert(ProductEntity product);
    Task<IEnumerable<ProductEntity>> GetAllAsync(CancellationToken cancellationToken = default);
}