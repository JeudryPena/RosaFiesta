using Domain.Entities.Product;
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
    public async Task<DiscountEntity> GetByIdAsync(Guid discountId, CancellationToken cancellationToken = default)
    {
        DiscountEntity? discount = await _dbContext.Discounts.FindAsync(discountId);
        if (discount == null)
        {
            throw new NullReferenceException("Discount not found");
        }
        return discount;
    }

    public void Insert(DiscountEntity discountEntity)
    => _dbContext.Discounts.Add(discountEntity);

    public void Update(DiscountEntity discount)
    => _dbContext.Discounts.Update(discount);

    public void Delete(DiscountEntity discount)
    => _dbContext.Discounts.Remove(discount);
}