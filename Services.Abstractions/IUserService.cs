using Contracts.Model.Security;
using Contracts.Model.Security.Response;

namespace Services.Abstractions;

public interface IUserService
{
	Task<IEnumerable<ManagementUsersResponse>> GetAllUserAsync(CancellationToken cancellationToken = default);
	Task<UserResponse> GetUserByIdAsync(string userId, CancellationToken cancellationToken = default);
	Task UpdateAsync(string? updaterId, string userId, UserForCreationDto userForUpdateDto,
		CancellationToken cancellationToken = default);
	Task DeleteAsync(string userId, CancellationToken cancellationToken = default);
	Task UnlockUserAsync(string userId, string? unlockerId, CancellationToken cancellationToken);
	Task CreateAsync(UserForCreationDto userForCreationDto, string? userId, CancellationToken cancellationToken = default);
	Task LockUserAsync(string userId, string? lockerId, CancellationToken cancellationToken = default);
	Task<IEnumerable<UsersListResponse>> GetUsersListAsync(CancellationToken cancellationToken = default);
	Task<IEnumerable<RolesListResponse>> GetRolesListAsync(CancellationToken cancellationToken = default);
	Task<string> GetUserName(string userId, CancellationToken cancellationToken);
	
	/// <summary>
	/// Change promotional emails status
	/// </summary>
	/// <param name="userId"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task ChangePromotionalEmailsAsync(string userId, CancellationToken cancellationToken);

	/// <summary>
	/// Delete my user
	/// </summary>
	/// <param name="userId"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task DeleteMyUserAsync(string userId, CancellationToken cancellationToken);
}
