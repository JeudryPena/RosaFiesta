using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface ICartService
{
    Task<IEnumerable<CartResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CartResponse> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<CartResponse> AddToCartAsync(string userId, List<PurchaseDetailDto> cartItems,
        CancellationToken cancellationToken = default);

    Task<CartResponse> AdjustCartItemQuantityAsync(string userId, string productId, int decrease, CancellationToken cancellationToken = default);
    
}