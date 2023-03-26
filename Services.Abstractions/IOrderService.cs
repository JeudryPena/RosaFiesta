using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract;
using Contracts.Model.Product.UserInteract.Response;

namespace Services.Abstractions;

public interface IOrderService
{
    Task<IEnumerable<OrderResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<OrderResponse> GetByIdAsync(int billId, CancellationToken cancellationToken = default);
    Task<OrderResponse> OrderPurchaseAsync(string userId, Guid payMethodId, OrderDto orderDto,
        CancellationToken cancellationToken = default);

    Task<ValidDiscountResponse> ApplyDiscountAsync(int purchaseNumber, string userId, string discountCode,
        CancellationToken cancellationToken);
    Task RemoveDiscountAsync(int purchaseNumber, CancellationToken cancellationToken = default);
    Task<ValidDiscountResponse> UpdateDiscountAsync(string userId, int purchaseNumber, string discountCode,
        CancellationToken cancellationToken);
}