using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract;
using Contracts.Model.Product.UserInteract.Response;
using Contracts.Model.Security;

namespace Services.Abstractions;

public interface IOrderService
{
    Task<IEnumerable<OrderPreviewResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<OrderPreviewResponse>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default);
    Task<OrderResponse> GetByIdAsync(int billId, CancellationToken cancellationToken = default);
    Task<OrderResponse> OrderPurchaseAsync(string userId, Guid payMethodId, Guid addressId,
        CancellationToken cancellationToken = default);
    Task RemoveDiscountAsync(string userId, int purchaseNumber, CancellationToken cancellationToken = default);
    Task<ValidDiscountResponse> SelectDiscountAsync(string userId, int purchaseNumber, Guid? discountId,
        int optionId,
        CancellationToken cancellationToken = default);
    Task ReturnOrderDetailAsync(string userId, int purchaseNumber, int orderId, CancellationToken cancellationToken);
}