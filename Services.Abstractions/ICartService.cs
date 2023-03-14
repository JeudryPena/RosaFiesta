using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface ICartService
{
    Task<IEnumerable<CartResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CartResponse> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<CartResponse> AddToCartAsync(string userId, List<CartItemsDto> cartItems,
        CancellationToken cancellationToken = default);
}