using Domain.Entities;
using Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

internal sealed class OwnerRepository : IOwnerRepository
{
    private readonly RosaFiestaContext _dbContext;
    public OwnerRepository(RosaFiestaContext dbContext) => _dbContext = dbContext;
    public async Task<IEnumerable<OwnerEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _dbContext.Owners.Include(x => x.Accounts).ToListAsync(cancellationToken);

    public async Task<OwnerEntity> GetByIdAsync(Guid ownerId, CancellationToken cancellationToken = default) =>
        await _dbContext.Owners.Include(x => x.Accounts).FirstOrDefaultAsync(x => x.Id == ownerId, cancellationToken);
    public void Insert(OwnerEntity ownerEntity) => _dbContext.Owners.Add(ownerEntity);
    public void Remove(OwnerEntity ownerEntity) => _dbContext.Owners.Remove(ownerEntity);
}
