using Domain.Entities;

namespace Domain.IRepository;

public interface IProductRepository
{
    void Insert(ProductEntity product);
}