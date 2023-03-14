using Domain.Entities.Product.UserInteract;

namespace Domain.IRepository;

public interface IOrderRepository
{
    Task<IEnumerable<OrderEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<OrderEntity> GetByIdAsync(int billId, CancellationToken cancellationToken = default);
    void CreateAsync(OrderEntity order);
    void Update(OrderEntity order);
    void Delete(OrderEntity order);
}