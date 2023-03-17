using Domain.Entities;
using Domain.Entities.Security;

namespace Domain.IRepository;

public interface IUserRepository
{
    Task<IEnumerable<UserEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<UserEntity> GetByIdAsync(string userId, CancellationToken cancellationToken = default);
    void Insert(UserEntity user);
    void Delete(UserEntity user);
    void CreateAsync(UserEntity user);
    void Update(UserEntity user);
}
