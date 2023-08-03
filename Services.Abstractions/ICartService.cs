using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract;

namespace Services.Abstractions;

public interface ICartService
{
	Task<CartResponse> GetByIdAsync(string id, CancellationToken cancellationToken = default);
	Task AddPackToCartAsync(string userId, Guid optionId, List<PurchaseDetailDto> cartItems,
		CancellationToken cancellationToken = default);
	Task AdjustCartItemQuantityAsync(string userId, Guid purchaseNumber, Guid optionId, int adjust,
		CancellationToken cancellationToken = default);
	Task RemoveCartItemAsync(string userId, Guid detailId, Guid? optionId,
		CancellationToken cancellationToken = default);
	Task ClearCartAsync(string userId, CancellationToken cancellationToken = default);
	Task AddProductToCartAsync(string userId, PurchaseDetailDto cartItem,
		CancellationToken cancellationToken = default);
	Task<int> GetCartDetailsCountAsync(string userId, CancellationToken cancellationToken = default);
}