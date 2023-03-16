using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface IOrderService
{
    Task<IEnumerable<BillResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<BillResponse> GetByIdAsync(int billId, CancellationToken cancellationToken = default);
    Task<BillResponse> CreateAsync(OrderDto orderDto, CancellationToken cancellationToken = default);
    Task<BillResponse> UpdateAsync(int billId, OrderDto orderDto, CancellationToken cancellationToken = default);
    Task DeleteAsync(int billId, CancellationToken cancellationToken = default);
    Task<OrderResponse> OrderPurchaseAsync(string userId, Guid payMethodId, OrderDto orderDto,
        CancellationToken cancellationToken = default);
}