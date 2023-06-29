using Domain.Entities.Product;
using Domain.IRepository;

using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

internal sealed class WarrantyRepository : IWarrantyRepository
{
	private readonly RosaFiestaContext _dbContext;

	public WarrantyRepository(RosaFiestaContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<IEnumerable<WarrantyEntity>> GetAllManagementAsync(CancellationToken cancellationToken = default) =>
		await _dbContext.Warranties.Include(x => x.Products).ToListAsync(cancellationToken);

	public async Task<IEnumerable<WarrantyEntity>> GetAllAsync(CancellationToken cancellationToken = default)
	=> await _dbContext.Warranties.ToListAsync(cancellationToken);

	public async Task<WarrantyEntity> GetByIdAsync(Guid warrantyId, CancellationToken cancellationToken = default)
	{
		WarrantyEntity? warranty = await _dbContext.Warranties.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == warrantyId, cancellationToken);
		if (warranty == null)
			throw new NullReferenceException($"Warranty with id {warrantyId} not found");
		return warranty;
	}
	public void Insert(WarrantyEntity warrantyEntity) => _dbContext.Warranties.Add(warrantyEntity);
	public void Update(WarrantyEntity warranty) => _dbContext.Warranties.Update(warranty);

	public void Delete(WarrantyEntity warranty)
	=> _dbContext.Warranties.Remove(warranty);
}