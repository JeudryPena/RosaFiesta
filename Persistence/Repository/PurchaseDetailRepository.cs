using Domain.Entities.Product.UserInteract;
using Domain.IRepository;

using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

internal sealed class PurchaseDetailRepository : IPurchaseDetailRepository
{
	private readonly RosaFiestaContext _rosaFiestaContext;

	public PurchaseDetailRepository(RosaFiestaContext rosaFiestaContext)
	{
		_rosaFiestaContext = rosaFiestaContext;
	}

	public async Task<IEnumerable<PurchaseDetailEntity>> GetAllAsync(CancellationToken cancellationToken) => await _rosaFiestaContext.PurchaseDetails.ToListAsync(cancellationToken);

	public async Task<PurchaseDetailEntity> GetByIdAsync(Guid detailId, CancellationToken cancellationToken)
	{
		PurchaseDetailEntity? purchaseDetail = await _rosaFiestaContext.PurchaseDetails.Include(x => x.PurchaseOptions).FirstOrDefaultAsync(x => x.Id == detailId, cancellationToken);
		if (purchaseDetail == null)
			throw new NullReferenceException(nameof(PurchaseDetailEntity));
		return purchaseDetail;
	}

	public void Update(PurchaseDetailEntity purchaseDetail) => _rosaFiestaContext.PurchaseDetails.Update(purchaseDetail);

	public async Task<PurchaseDetailOptions> GetOptionDetailAsync(Guid optionId, Guid detailId, CancellationToken cancellationToken)
	{
		PurchaseDetailOptions? purchaseDetailOptions = await _rosaFiestaContext.PurchaseDetailsOptions.FirstOrDefaultAsync(x => x.OptionId == optionId && x.DetailId == detailId, cancellationToken);
		if (purchaseDetailOptions == null)
			throw new NullReferenceException(nameof(PurchaseDetailOptions));
		return purchaseDetailOptions;
	}

	public void UpdateOptionDetail(PurchaseDetailOptions detail)
	=> _rosaFiestaContext.PurchaseDetailsOptions.Update(detail);

	public async Task<int> GetCountAsync(CancellationToken cancellationToken)
	{
		int count = await _rosaFiestaContext.Orders.CountAsync(cancellationToken);
		return count;
	}

	public async Task CreateAsync(PurchaseDetailEntity newDetail)
	{
		await _rosaFiestaContext.PurchaseDetails.AddAsync(newDetail);
	}
}