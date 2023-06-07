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

	public async Task<IEnumerable<WarrantyEntity>> GetAllAsync(CancellationToken cancellationToken = default)
	=> await _dbContext.Warranties.Where(x => x.IsDeleted == false).ToListAsync(cancellationToken);

	public async Task<WarrantyEntity> GetByIdAsync(Guid warrantyId, CancellationToken cancellationToken = default)
	{
		WarrantyEntity? warranty = await _dbContext.Warranties.FirstOrDefaultAsync(x => x.Id == warrantyId, cancellationToken);
		if (warranty == null)
			throw new NullReferenceException($"Warranty with id {warrantyId} not found");
		if (warranty.IsDeleted)
			throw new Exception($"Warranty with id {warrantyId} is deleted");
		return warranty;
	}
	public void Insert(WarrantyEntity warrantyEntity) => _dbContext.Warranties.Add(warrantyEntity);
	public void Update(WarrantyEntity warranty) => _dbContext.Warranties.Update(warranty);
}