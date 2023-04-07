using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract;
using Contracts.Model.Product.UserInteract.Response;

namespace Services.Abstractions;

public interface ICartService
{
    Task<IEnumerable<CartResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CartResponse> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<IEnumerable<ProductsDiscountResponse>> GetDiscountsPreviewAsync(string userId, string productCode, int optionId, CancellationToken cancellationToken = default);
    Task<CartResponse> AddPackToCartAsync(string userId, int optionId, string? discountCode, List<PurchaseDetailDto> cartItems,
        CancellationToken cancellationToken = default);
    Task<OptionDetailResponse> AdjustCartItemQuantityAsync(int purchaseNumber, int optionId, int adjust,
        CancellationToken cancellationToken = default);
    Task<CartResponse> RemoveCartItemAsync(string userId, string productId, int? optionId,
        CancellationToken cancellationToken = default);
    Task<CartResponse> ClearCartAsync(string userId, CancellationToken cancellationToken = default);
    Task<CartResponse> AddProductToCartAsync(string userId, string? discountCode, PurchaseDetailDto cartItem,
        CancellationToken cancellationToken = default);
} 