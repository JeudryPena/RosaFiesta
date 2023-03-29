using Domain.Entities.Product.UserInteract;

namespace Domain.IRepository;

public interface ICartRepository
{
    Task<IEnumerable<CartEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CartEntity> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    void UpdateCartItem(PurchaseDetailEntity cartItem);
    void DeleteDetails(ICollection<PurchaseDetailEntity> cartDetails);
    void UpdateCart(CartEntity cart);
    Task<CartEntity> GetCartWithProductAndOption(string userId, CancellationToken cancellationToken);
    Task<ICollection<PurchaseDetailEntity>> GetCartDetails(string userId, CancellationToken cancellationToken);
}