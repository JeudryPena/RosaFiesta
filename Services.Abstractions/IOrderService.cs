using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract.Response;

namespace Services.Abstractions;

public interface IOrderService
{
	Task<IEnumerable<OrderManagementPreviewResponse>> GetAllAsync(int? ordersToTake = null,
		CancellationToken cancellationToken = default);
	Task<IEnumerable<OrderPreviewResponse>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default);
	Task<OrderResponse> GetByIdAsync(Guid billId, CancellationToken cancellationToken = default);
	Task<OrderResponse> OrderPurchaseAsync(OrderDto orderDto, string userId,
		CancellationToken cancellationToken = default);
	Task<bool> ReturnOrderDetailAsync(string userId, Guid orderId,
		CancellationToken cancellationToken);
	Task<OrderResponse> CreateOrderAsync(OrderDto orderDto, string userId, CancellationToken cancellationToken);
	Task<double> GetGainsAsync(CancellationToken cancellationToken);
	Task<bool> OficializeReturnOrderDetailAsync(string userId, Guid orderId, CancellationToken cancellationToken);
	Task<OrderComparativeResponse> GetOrderCompareAsync(DateOnly start, DateOnly end, CancellationToken cancellationToken);
	Task<AnalyticDataResponse> GetAnalyticDataAsync(DateOnly start, DateOnly end, CancellationToken cancellationToken);
}