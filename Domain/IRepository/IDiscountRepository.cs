using Domain.Entities.Product;

namespace Domain.IRepository;

public interface IDiscountRepository
{
	Task<IEnumerable<DiscountEntity>> GetAllAsync(CancellationToken cancellationToken = default);
	Task<DiscountEntity> GetByIdAsync(Guid discountId, CancellationToken cancellationToken = default);
	void Insert(DiscountEntity discountEntity);
	void Update(DiscountEntity discount);
	Task<DiscountEntity> GetDiscountAsync(Guid discountId, CancellationToken cancellationToken = default);
	void Delete(DiscountEntity discount);
	Task<DiscountEntity?> GetOptionDiscountAsync(Guid id, CancellationToken cancellationToken);
	Task<DiscountEntity> GetHotOffersAsync(CancellationToken cancellationToken);
}