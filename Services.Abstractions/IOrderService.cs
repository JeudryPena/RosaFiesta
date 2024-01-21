using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract.Response;

namespace Services.Abstractions;

public interface IOrderService
{
	Task<IEnumerable<OrderPreviewResponse>> GetAllAsync(CancellationToken cancellationToken = default);
	Task<IEnumerable<OrderPreviewResponse>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default);
	Task<OrderResponse> GetByIdAsync(Guid billId, CancellationToken cancellationToken = default);
	Task<OrderResponse> OrderPurchaseAsync(OrderDto orderDto, string userId,
		CancellationToken cancellationToken = default);
	Task ReturnOrderDetailAsync(string userId, Guid purchaseNumber, Guid orderId,
		CancellationToken cancellationToken);
	Task<OrderResponse> CreateOrderAsync(OrderDto orderDto, string userId, CancellationToken cancellationToken);
}