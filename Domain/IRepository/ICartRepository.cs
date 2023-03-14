using Domain.Entities.Product.UserInteract;

namespace Domain.IRepository;

public interface ICartRepository
{
    Task<IEnumerable<CartEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CartEntity> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    void Insert(List<CartProductsEntity> cartProducts);
}