using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract;

namespace Services.Abstractions;

public interface ICartService
{
	Task<CartResponse> GetByIdAsync(string id, CancellationToken cancellationToken = default);
	Task<IEnumerable<ProductsDiscountResponse>> GetDiscountsPreviewAsync(string userId, Guid productId, int optionId, CancellationToken cancellationToken = default);
	Task<CartResponse> AddPackToCartAsync(string userId, Guid? discountId, int optionId, List<PurchaseDetailDto> cartItems,
		CancellationToken cancellationToken = default);
	Task AdjustCartItemQuantityAsync(string userId, int purchaseNumber, int optionId, int adjust,
		CancellationToken cancellationToken = default);
	Task<CartResponse> RemoveCartItemAsync(string userId, Guid productId, int? optionId,
		CancellationToken cancellationToken = default);
	Task<CartResponse> ClearCartAsync(string userId, CancellationToken cancellationToken = default);
	Task<CartResponse> AddProductToCartAsync(string userId, Guid? discountId, PurchaseDetailDto cartItem,
		CancellationToken cancellationToken = default);
}