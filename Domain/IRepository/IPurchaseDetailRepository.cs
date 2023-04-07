using Domain.Entities.Product.UserInteract;

namespace Domain.IRepository;

public interface IPurchaseDetailRepository
{
    Task<IEnumerable<PurchaseDetailEntity>> GetAllAsync(CancellationToken cancellationToken);
    Task<PurchaseDetailEntity> GetByIdAsync(int detailId, CancellationToken cancellationToken);
    void Update(PurchaseDetailEntity purchaseDetail);
    void Delete(PurchaseDetailEntity purchaseDetail);
    void UpdateRange(ICollection<PurchaseDetailEntity> cartDetails);
    Task<PurchaseDetailOptions> GetOptionDetailAsync(int optionId, int purchaseNumber, CancellationToken cancellationToken);
    Task<PurchaseDetailOptions> GetDetailOptionByIdAsync(int optionId, int purchaseNumber, CancellationToken cancellationToken);
    void UpdateOptionDetail(PurchaseDetailOptions detail);
}