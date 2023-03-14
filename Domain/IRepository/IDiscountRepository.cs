using Domain.Entities.Product;

namespace Domain.IRepository;

public interface IDiscountRepository
{
    Task<IEnumerable<DiscountEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<DiscountEntity> GetByIdAsync(Guid discountId, CancellationToken cancellationToken = default);
    void Insert(DiscountEntity discountEntity);
    void Update(DiscountEntity discount);
    void Delete(DiscountEntity discount);
}