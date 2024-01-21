using Domain.Entities.Security;

using Microsoft.AspNetCore.Identity;

namespace Domain.IRepository;

public interface IUserRepository
{
	Task<IEnumerable<UserEntity>> GetAllAsync(CancellationToken cancellationToken = default);
	Task<UserEntity> GetByIdAsync(string userId, CancellationToken cancellationToken = default);
	void Insert(UserEntity user);
	void CreateAsync(UserEntity user);
	void Update(UserEntity user);
	Task<string> GetUserName(string userId, CancellationToken cancellationToken);
	void Delete(UserEntity user);
	Task<IEnumerable<RoleEntity>> GetAllRolesAsync(CancellationToken cancellationToken = default);
	Task<IEnumerable<UserEntity>> GetUsersList(CancellationToken cancellationToken = default);
	Task<IEnumerable<RoleEntity>> GetRolesList(CancellationToken cancellationToken = default);
}
