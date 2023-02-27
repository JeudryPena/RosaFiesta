using Domain.Entities;

namespace Domain.IRepository;

public interface IUserRepository
{
    Task<IEnumerable<UserEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<UserEntity> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default);
    void Insert(UserEntity user);
}
