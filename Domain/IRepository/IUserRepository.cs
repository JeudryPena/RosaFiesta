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
	Task VerifyUserAlredyExistsAsync(string? username, string userId, CancellationToken cancellationToken);
	Task VerifyEmailAlredyExistsAsync(string email, string userId, CancellationToken cancellationToken);
	Task VerifyIfUserAlredyExistsAsync(string userName, CancellationToken cancellationToken);
	Task VerifyIfEmailAlredyExistsAsync(string email, CancellationToken cancellationToken);
	Task<List<string>> GetAdminEmails(CancellationToken cancellationToken);
	Task<List<string>> GetAllUsersWithPromoEnabled(CancellationToken cancellationToken);
	Task<int> GetTotalClientsWithDatesAsync(CancellationToken cancellationToken, DateOnly start, DateOnly end);
}
