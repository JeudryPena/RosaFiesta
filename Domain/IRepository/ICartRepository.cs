using Domain.Entities.Product.UserInteract;

namespace Domain.IRepository;

public interface ICartRepository
{
    Task<IEnumerable<CartEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CartEntity> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    void Insert(CartEntity cart);
    void UpdateCartItem(PurchaseDetailEntity cartItem);
    void DeleteDetails(ICollection<PurchaseDetailEntity> cartDetails);
}