using Domain.Entities.Product;
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

	public async Task<DiscountEntity> GetDiscountAsync(Guid discountId, CancellationToken cancellationToken = default)
	{
		DiscountEntity? discount = await _dbContext.Discounts.FirstOrDefaultAsync(x => x.Id == discountId, cancellationToken);
		if (discount == null)
			throw new NullReferenceException("Value not found");
		return discount;
	}

	public async Task<DiscountEntity?> GetOptionDiscountAsync(Guid optionId, CancellationToken cancellationToken = default)
	{
		DiscountEntity? discount = await _dbContext.Discounts.Include(x => x.ProductsDiscounts).Where(x => x.Start <= DateTime.Now && x.End >= DateTime.Now && x.ProductsDiscounts.Any(x => x.OptionId == optionId)).OrderByDescending(x => x.Value).FirstOrDefaultAsync(cancellationToken);
		return discount;
	}

	public void Delete(DiscountEntity discount)
	=> _dbContext.Discounts.Remove(discount);
}