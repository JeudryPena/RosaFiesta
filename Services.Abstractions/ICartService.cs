using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface ICartService
{
    Task<IEnumerable<CartResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CartResponse> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<CartResponse> AddPackToCartAsync(string userId, List<PurchaseDetailDto> cartItems,
        CancellationToken cancellationToken = default);
    Task<CartResponse> AdjustCartItemQuantityAsync(string userId, string productId, int adjust, CancellationToken cancellationToken = default);
    Task<CartResponse> RemoveCartItemAsync(string userId, string productId, CancellationToken cancellationToken = default);
    Task<CartResponse> ClearCartAsync(string userId, CancellationToken cancellationToken = default);
    Task<CartResponse> AddProductToCartAsync(string userId, PurchaseDetailDto cartItem, CancellationToken cancellationToken = default);
} 