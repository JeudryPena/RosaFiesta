using Domain.Entities;
using Domain.Entities.Product;

namespace Domain.IRepository;

public interface IProductRepository
{
    void Insert(ProductEntity product);
}