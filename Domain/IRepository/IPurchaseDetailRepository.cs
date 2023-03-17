using Domain.Entities.Product.UserInteract;

namespace Domain.IRepository;

public interface IPurchaseDetailRepository
{
    Task<IEnumerable<PurchaseDetailEntity>> GetAllAsync(CancellationToken cancellationToken);
    Task<PurchaseDetailEntity> GetByIdAsync(int detailId, CancellationToken cancellationToken);
    void Update(PurchaseDetailEntity purchaseDetail);
    void Delete(PurchaseDetailEntity purchaseDetail);
}