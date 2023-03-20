using Domain.Entities.Product;
using Domain.Entities.Product.UserInteract;
using Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

internal sealed class DiscountRepository: IDiscountRepository
{
    private readonly RosaFiestaContext _dbContext;
    
    public DiscountRepository(RosaFiestaContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<DiscountEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    => await _dbContext.Discounts.ToListAsync(cancellationToken);
    public async Task<DiscountEntity> GetByIdAsync(string discountId, CancellationToken cancellationToken = default)
    {
        DiscountEntity? discount = await _dbContext.Discounts.Include(x => x.AppliedDiscounts).Include(x => x.Products).FirstOrDefaultAsync(x => x.DiscountCode == discountId, cancellationToken);
        if (discount == null)
        {
            throw new NullReferenceException("DiscountValue not found");
        }
        return discount;
    }

    public void Insert(DiscountEntity discountEntity)
    => _dbContext.Discounts.Add(discountEntity);

    public void Update(DiscountEntity discount)
    => _dbContext.Discounts.Update(discount);

    public void Delete(DiscountEntity discount)
    => _dbContext.Discounts.Remove(discount);

    public async Task<DiscountEntity> GetValidDiscountAsync(string discountCode, string productId,
        CancellationToken cancellationToken = default)
    {
        DiscountEntity? discount = await _dbContext.Discounts
            .FirstOrDefaultAsync(d => d.DiscountCode == discountCode && d.DiscountStartDate <= DateTimeOffset.UtcNow && d.DiscountEndDate >= DateTimeOffset.UtcNow, cancellationToken);
        if (discount == null)
            throw new NullReferenceException("DiscountValue not found");
        if (discount.Products == null || discount.Products.All(p => p.ProductCode != productId))
            throw new NullReferenceException("The discount does not apply for this product");
        return discount;
    }

    public async Task<AppliedDiscountEntity> GetAppliedDiscount(int purchaseNumber, CancellationToken cancellationToken = default)
    {
        AppliedDiscountEntity? appliedDiscount = await _dbContext.AppliedDiscounts
            .FirstOrDefaultAsync(ad => ad.PurchaseNumber == purchaseNumber, cancellationToken);
        if (appliedDiscount == null)
            throw new NullReferenceException("AppliedDiscount not found");
        return appliedDiscount;
    }

    public void UpdateAppliedDiscount(AppliedDiscountEntity discountApplied)
    => _dbContext.AppliedDiscounts.Update(discountApplied);

    public void CreateAppliedDiscount(AppliedDiscountEntity discountApplied)
    => _dbContext.AppliedDiscounts.Add(discountApplied);

    public void DeleteAppliedDiscount(AppliedDiscountEntity appliedDiscount)
    => _dbContext.AppliedDiscounts.Remove(appliedDiscount);

    public async Task<DiscountEntity> GetByAppliedId(int? detailAppliedId, CancellationToken cancellationToken = default)
    {
        DiscountEntity? discount = await _dbContext.Discounts
            .FirstOrDefaultAsync(d => d.AppliedDiscounts != null && d.AppliedDiscounts.Any(ad => ad.Id == detailAppliedId), cancellationToken);
        if (discount == null)
            throw new NullReferenceException("DiscountValue not found");
        return discount;
    }
}