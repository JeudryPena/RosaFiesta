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
        DiscountEntity? discount = await _dbContext.Discounts.Include(x => x.AppliedDiscounts).Include(x => x.DiscountProducts).Include(x => x.DiscountPurchases)  .FirstOrDefaultAsync(x => x.DiscountCode == discountId, cancellationToken);
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
            .Include(d => d.DiscountProducts).Include(d => d.AppliedDiscounts)
            .FirstOrDefaultAsync(d => d.DiscountCode == discountCode && d.DiscountStartDate <= DateTimeOffset.UtcNow && d.DiscountEndDate >= DateTimeOffset.UtcNow, cancellationToken);
        if (discount == null)
            throw new NullReferenceException("DiscountValue not found");
        if (discount.DiscountProducts != null && discount.DiscountProducts.All(dp => dp.DiscountAppliedId != productId))
            throw new NullReferenceException("The discount does not apply for this product");
        return discount;
    }

    public async Task<AppliedDiscountEntity> GetAppliedDiscount(string userId, string discountCode, CancellationToken cancellationToken = default)
    {
        AppliedDiscountEntity? appliedDiscount = await _dbContext.AppliedDiscounts
            .FirstOrDefaultAsync(ad => ad.UserId == userId && ad.DiscountCode == discountCode, cancellationToken) ?? throw new NullReferenceException("Applied discount not found");
        return appliedDiscount;
    }

    public void UpdateAppliedDiscount(AppliedDiscountEntity discountApplied)
    {
        _dbContext.AppliedDiscounts.Update(discountApplied);
    }
}