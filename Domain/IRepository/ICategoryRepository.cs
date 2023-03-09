using Domain.Entities.Product;

namespace Domain.IRepository;

public interface ICategoryRepository
{
    Task<IEnumerable<CategoryEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    void Insert(CategoryEntity category);
}