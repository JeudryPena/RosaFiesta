﻿using Domain.Entities.Product;
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
    => await _dbContext.Discounts.Include(x => x.ProductsDiscounts).ToListAsync(cancellationToken);
    public async Task<DiscountEntity> GetByIdAsync(string discountId, CancellationToken cancellationToken = default)
    {
        DiscountEntity? discount = await _dbContext.Discounts.Include(x => x.ProductsDiscounts).FirstOrDefaultAsync(x => x.DiscountCode == discountId, cancellationToken);
        if (discount == null)
            throw new NullReferenceException("DiscountValue not found");
        return discount;
    }

    public void Insert(DiscountEntity discountEntity)
    => _dbContext.Discounts.Add(discountEntity);

    public void Update(DiscountEntity discount)
    => _dbContext.Discounts.Update(discount);

    public void Delete(DiscountEntity discount)
    => _dbContext.Discounts.Remove(discount);
    
    public async Task<AppliedDiscountEntity> GetAppliedDiscount(int purchaseNumber, CancellationToken cancellationToken = default)
    {
        AppliedDiscountEntity? appliedDiscount = await _dbContext.AppliedDiscounts
            .FirstOrDefaultAsync(d => d.PurchaseOption.PurchaseNumber == purchaseNumber, cancellationToken);
        if (appliedDiscount == null)
            throw new NullReferenceException("DiscountValue not found");
        return appliedDiscount;
    }
    
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

    public async Task<ICollection<DiscountEntity>> GetValidDiscountsPreview(string userId, string productCode,
        int optionId, CancellationToken cancellationToken)
    {
        ICollection<DiscountEntity> discounts = await _dbContext.Discounts.Where(
            x => x.AppliedDiscounts != null && x.ProductsDiscounts != null &&
                 x.DiscountStartDate <= DateTimeOffset.UtcNow && x.DiscountEndDate >= DateTimeOffset.UtcNow &&
                 x.ProductsDiscounts.Any(p => p.DiscountCode == x.DiscountCode &&
                                         ((p.OptionId == optionId || p.ProductId == productCode) || (p.OptionId == null && p.ProductId == null))) &&
                 x.AppliedDiscounts.Any(d =>
                     x.AppliedDiscounts.Count(a => a.UserId == userId && a.DiscountCode == d.DiscountCode) *
                     d.PurchaseOption.Quantity <= x.MaxTimesApply)).ToListAsync( cancellationToken);
        return discounts;
    }

    public async Task<DiscountEntity> GetDiscountAsync(string discountId, CancellationToken cancellationToken = default)
    {
        DiscountEntity? discount = await _dbContext.Discounts.FirstOrDefaultAsync(x => x.DiscountCode == discountId, cancellationToken);
        if (discount == null)
            throw new NullReferenceException("DiscountValue not found");
        return discount;
    }

    public async Task<DiscountEntity> GetValidDiscount(string productCode, int optionId, string userId,
        CancellationToken cancellationToken = default)
    {
        DiscountEntity? discount = await _dbContext.Discounts
            .FirstOrDefaultAsync(x => x.AppliedDiscounts != null && x.ProductsDiscounts != null && x.DiscountStartDate <= DateTimeOffset.UtcNow && x.DiscountEndDate >= DateTimeOffset.UtcNow && x.ProductsDiscounts.Any(p => p.DiscountCode == x.DiscountCode && ((p.OptionId == optionId || p.ProductId == productCode) || (p.OptionId == null && p.ProductId == null))) && x.AppliedDiscounts.Any(d => x.AppliedDiscounts.Count(a => a.UserId == userId && a.DiscountCode == d.DiscountCode) * d.PurchaseOption.Quantity <= x.MaxTimesApply), cancellationToken);
        if (discount == null)
            throw new NullReferenceException("DiscountValue not found");
        return discount;
    }
}