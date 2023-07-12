using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract.Response;

namespace Services.Abstractions;

public interface IOrderService
{
	Task<IEnumerable<OrderPreviewResponse>> GetAllAsync(CancellationToken cancellationToken = default);
	Task<IEnumerable<OrderPreviewResponse>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default);
	Task<OrderResponse> GetByIdAsync(Guid billId, CancellationToken cancellationToken = default);
	Task<OrderResponse> OrderPurchaseAsync(string userId, Guid payMethodId, Guid addressId,
		CancellationToken cancellationToken = default);
	Task ReturnOrderDetailAsync(string userId, Guid purchaseNumber, Guid orderId, CancellationToken cancellationToken);
}