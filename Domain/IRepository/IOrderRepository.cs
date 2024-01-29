using Domain.Entities.Product.UserInteract;

namespace Domain.IRepository;

public interface IOrderRepository
{
    Task<IEnumerable<OrderEntity>> GetAllAsync(int? ordersToTake = null, CancellationToken cancellationToken = default);
    Task<OrderEntity> GetByIdAsync(Guid billId, CancellationToken cancellationToken = default);
    void CreateAsync(OrderEntity order);
    Task<IEnumerable<OrderEntity>> GetByUserIdAsync(string userId, CancellationToken cancellationToken);
    void Update(OrderEntity order);
    Task<double> GetGainsAsync(CancellationToken cancellationToken);
    Task<OrderComparativeData> GetOrderCompareAsync(DateOnly start, DateOnly end, CancellationToken cancellationToken);
    Task<OrderComparativeData> GetQuotesCompareAsync(DateOnly start, DateOnly end, CancellationToken cancellationToken);
    Task<OrderComparativeData> GetRefundsCompareAsync(DateOnly start, DateOnly end, CancellationToken cancellationToken);

    Task<double> GetGainsWithDatesAsync(CancellationToken cancellationToken, DateOnly start, DateOnly end);
}