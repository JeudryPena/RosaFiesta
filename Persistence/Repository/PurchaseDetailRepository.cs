﻿using Domain.Entities.Product.UserInteract;
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
        PurchaseDetailEntity? purchaseDetail = await _rosaFiestaContext.PurchaseDetails.FirstOrDefaultAsync(x => x.PurchaseNumber == detailId, cancellationToken);
        if(purchaseDetail == null)
            throw new NullReferenceException(nameof(PurchaseDetailEntity));
        return purchaseDetail;
    }

    public void Update(PurchaseDetailEntity purchaseDetail) => _rosaFiestaContext.PurchaseDetails.Update(purchaseDetail);

    public void Delete(PurchaseDetailEntity purchaseDetail) => _rosaFiestaContext.PurchaseDetails.Remove(purchaseDetail);
    public void UpdateRange(ICollection<PurchaseDetailEntity> cartDetails) =>
    _rosaFiestaContext.PurchaseDetails.UpdateRange(cartDetails);
}