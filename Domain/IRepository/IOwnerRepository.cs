using Domain.Entities;

namespace Domain.IRepository;

public interface IOwnerRepository
{
    Task<IEnumerable<OwnerEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<OwnerEntity> GetByIdAsync(Guid ownerId, CancellationToken cancellationToken = default);
    void Insert(OwnerEntity ownerEntity);
    void Remove(OwnerEntity ownerEntity);
}
