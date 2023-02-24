using Domain.Entities;
using Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

internal sealed class AccountRepository : IAccountRepository
{
    private readonly RosaFiestaContext _dbContext;
    public AccountRepository(RosaFiestaContext dbContext) => _dbContext = dbContext;
    public async Task<IEnumerable<AccountEntity>> GetAllByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default) =>
        await _dbContext.Accounts.Where(x => x.OwnerId == ownerId).ToListAsync(cancellationToken);
    public async Task<AccountEntity> GetByIdAsync(Guid accountId, CancellationToken cancellationToken = default) =>
        await _dbContext.Accounts.FirstOrDefaultAsync(x => x.Id == accountId, cancellationToken);
    public void Insert(AccountEntity accountEntity) => _dbContext.Accounts.Add(accountEntity);
    public void Remove(AccountEntity accountEntity) => _dbContext.Accounts.Remove(accountEntity);
}
