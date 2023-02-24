using Domain.IRepository;

namespace Persistence.Repository;

internal sealed class UnitOfWork: IUnitOfWork
{
    private readonly RosaFiestaContext _dbContext;
    
    public UnitOfWork(RosaFiestaContext dbContext) => _dbContext = dbContext;

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => _dbContext.SaveChangesAsync(cancellationToken);
}