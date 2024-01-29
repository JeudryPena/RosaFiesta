using Domain.Entities.Product.UserInteract;

namespace Domain.IRepository;

public interface IPurchaseDetailRepository
{
	Task<IEnumerable<PurchaseDetailEntity>> GetAllAsync(CancellationToken cancellationToken);
	Task<PurchaseDetailEntity> GetByIdAsync(Guid detailId, CancellationToken cancellationToken);
	void Update(PurchaseDetailEntity purchaseDetail);
	Task<PurchaseDetailOptions> GetOptionDetailAsync(Guid optionId, Guid detailId, CancellationToken cancellationToken);
	void UpdateOptionDetail(PurchaseDetailOptions detail);
	Task<int> GetCountAsync(CancellationToken cancellationToken);
	Task CreateAsync(PurchaseDetailEntity newDetail);
	Task<OrderComparativeData> GetNotPurchasedCompareAsync(DateOnly start, DateOnly end, CancellationToken cancellationToken);
	
}