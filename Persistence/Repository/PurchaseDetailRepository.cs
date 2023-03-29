using Domain.Entities.Product.UserInteract;
using Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

internal sealed class PurchaseDetailRepository: IPurchaseDetailRepository
{
    private readonly RosaFiestaContext _rosaFiestaContext;
    
    public PurchaseDetailRepository(RosaFiestaContext rosaFiestaContext)
    {
        _rosaFiestaContext = rosaFiestaContext;
    }

    public async Task<IEnumerable<PurchaseDetailEntity>> GetAllAsync(CancellationToken cancellationToken) => await _rosaFiestaContext.PurchaseDetails.ToListAsync(cancellationToken);

    public async Task<PurchaseDetailEntity> GetByIdAsync(int detailId, CancellationToken cancellationToken)
    {
        PurchaseDetailEntity? purchaseDetail = await _rosaFiestaContext.PurchaseDetails.Include(x => x.DiscountApplied).FirstOrDefaultAsync(x => x.PurchaseNumber == detailId, cancellationToken);
        if(purchaseDetail == null)
            throw new NullReferenceException(nameof(PurchaseDetailEntity));
        return purchaseDetail;
    }

    public void Update(PurchaseDetailEntity purchaseDetail) => _rosaFiestaContext.PurchaseDetails.Update(purchaseDetail);

    public void Delete(PurchaseDetailEntity purchaseDetail) => _rosaFiestaContext.PurchaseDetails.Remove(purchaseDetail);
    public void UpdateRange(ICollection<PurchaseDetailEntity> cartDetails) =>
    _rosaFiestaContext.PurchaseDetails.UpdateRange(cartDetails);

    public async Task<PurchaseDetailEntity> GetDetailByProduct(string productCode, int? optionId,
        CancellationToken cancellationToken)
    {
        PurchaseDetailEntity? purchaseDetail;
        if(optionId == null)
            purchaseDetail = await _rosaFiestaContext.PurchaseDetails.FirstOrDefaultAsync(x => x.ProductId == productCode && x.OrderSku == null && x.OptionId == null, cancellationToken);
        else
            purchaseDetail =
                await _rosaFiestaContext.PurchaseDetails.FirstOrDefaultAsync(
                    x => x.OptionId == optionId && x.OrderSku == null, cancellationToken);
        if(purchaseDetail == null)
            throw new NullReferenceException(nameof(PurchaseDetailEntity));
        return purchaseDetail;
    }
}