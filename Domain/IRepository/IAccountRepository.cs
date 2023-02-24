using Domain.Entities;

namespace Domain.IRepository;

public interface IAccountRepository
{
    Task<IEnumerable<AccountEntity>> GetAllByOwnerIdAsync(
        Guid ownerId,
        CancellationToken cancellationToken = default
    );
    Task<AccountEntity> GetByIdAsync(Guid accountId, CancellationToken cancellationToken = default);
    void Insert(AccountEntity accountEntity);
    void Remove(AccountEntity accountEntity);
}
