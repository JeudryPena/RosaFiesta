using Domain.Entities.Product;
using Domain.Entities.Product.UserInteract;
using Domain.IRepository;

using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

internal sealed class DiscountRepository : IDiscountRepository
{
	private readonly RosaFiestaContext _dbContext;

	public DiscountRepository(RosaFiestaContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<IEnumerable<DiscountEntity>> GetAllAsync(CancellationToken cancellationToken = default)
	=> await _dbContext.Discounts.Include(x => x.ProductsDiscounts).ThenInclude(x => x.Option).ToListAsync(cancellationToken);
	public async Task<DiscountEntity> GetByIdAsync(Guid discountId, CancellationToken cancellationToken = default)
	{
		DiscountEntity? discount = await _dbContext.Discounts.Include(x => x.ProductsDiscounts).ThenInclude(x => x.Option).FirstOrDefaultAsync(x => x.Id == discountId, cancellationToken);
		if (discount == null)
			throw new NullReferenceException("Value not found");
		return discount;
	}

	public void Insert(DiscountEntity discountEntity)
	=> _dbContext.Discounts.Add(discountEntity);

	public void Update(DiscountEntity discount)
	=> _dbContext.Discounts.Update(discount);

	public async Task<AppliedDiscountEntity> GetAppliedDiscount(int purchaseNumber, CancellationToken cancellationToken = default)
	{
		AppliedDiscountEntity? appliedDiscount = await _dbContext.AppliedDiscounts
			.FirstOrDefaultAsync(d => d.PurchaseOption.PurchaseNumber == purchaseNumber, cancellationToken);
		if (appliedDiscount == null)
			throw new NullReferenceException("Value not found");
		return appliedDiscount;
	}

	public async Task<DiscountEntity> GetByAppliedId(int? detailAppliedId, CancellationToken cancellationToken = default)
	{
		DiscountEntity? discount = await _dbContext.Discounts
			.FirstOrDefaultAsync(d => d.AppliedDiscounts != null && d.AppliedDiscounts.Any(ad => ad.Id == detailAppliedId), cancellationToken);
		if (discount == null)
			throw new NullReferenceException("Value not found");
		return discount;
	}

	public async Task<ICollection<DiscountEntity>> GetValidDiscountsPreview(string userId,
		int optionId, CancellationToken cancellationToken)
	{
		ICollection<DiscountEntity> discounts = await _dbContext.Discounts.Where(
			x => x.AppliedDiscounts != null && x.ProductsDiscounts != null &&
				 x.Start <= DateTimeOffset.UtcNow && x.End >= DateTimeOffset.UtcNow &&
				 x.ProductsDiscounts.Any(p => p.DiscountId == x.Id &&
										 p.OptionId == optionId) &&
				 x.AppliedDiscounts.Any(d =>
					 x.AppliedDiscounts.Count(a => a.UserId == userId && a.DiscountId == d.DiscountId) *
					 d.PurchaseOption.Quantity <= x.MaxTimesApply)).ToListAsync(cancellationToken);
		return discounts;
	}

	public async Task<DiscountEntity> GetDiscountAsync(Guid discountId, CancellationToken cancellationToken = default)
	{
		DiscountEntity? discount = await _dbContext.Discounts.FirstOrDefaultAsync(x => x.Id == discountId, cancellationToken);
		if (discount == null)
			throw new NullReferenceException("Value not found");
		return discount;
	}

	public async Task<DiscountEntity> GetValidDiscount(int optionId, string userId,
		CancellationToken cancellationToken = default)
	{
		DiscountEntity? discount = await _dbContext.Discounts
			.FirstOrDefaultAsync(x => x.AppliedDiscounts != null && x.ProductsDiscounts != null && x.Start <= DateTimeOffset.UtcNow && x.End >= DateTimeOffset.UtcNow && x.ProductsDiscounts.Any(p => p.DiscountId == x.Id && p.OptionId == optionId) && x.AppliedDiscounts.Any(d => x.AppliedDiscounts.Count(a => a.UserId == userId && a.DiscountId == d.DiscountId) * d.PurchaseOption.Quantity <= x.MaxTimesApply), cancellationToken);
		if (discount == null)
			throw new NullReferenceException("Value not found");
		return discount;
	}

	public void UpdateAppliedDiscount(AppliedDiscountEntity appliedDiscount)
	=> _dbContext.AppliedDiscounts.Update(appliedDiscount);

	public void Delete(DiscountEntity discount)
	=> _dbContext.Discounts.Remove(discount);

	public void DeleteAppliedDiscount(AppliedDiscountEntity appliedDiscount)
	=> _dbContext.AppliedDiscounts.Remove(appliedDiscount);
}