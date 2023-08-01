using Domain.Entities.Product.UserInteract;

namespace Domain.IRepository;

public interface ICartRepository
{
	Task<CartEntity> GetByIdAsync(string id, CancellationToken cancellationToken = default);
	void UpdateCartItem(PurchaseDetailEntity cartItem);
	void UpdateCart(CartEntity cart);
	Task<ICollection<PurchaseDetailEntity>> GetCartDetails(string userId, CancellationToken cancellationToken);
	void UpdateDetailOption(PurchaseDetailOptions optionDetail);
	Task<int> GetCartDetailsCountAsync(string userId, CancellationToken cancellationToken = default);
}