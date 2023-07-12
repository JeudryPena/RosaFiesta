using Contracts.Model.Security;
using Contracts.Model.Security.Response;

namespace Services.Abstractions;

public interface IUserService
{
	Task<IEnumerable<ManagementUsersResponse>> GetAllUserAsync(CancellationToken cancellationToken = default);
	Task<UsersResponse> GetUserByIdAsync(string userId, CancellationToken cancellationToken = default);
	Task UpdateAsync(string? updaterId, string userId, UserForUpdateDto userForUpdateDto,
		CancellationToken cancellationToken = default);
	Task DeleteAsync(string userId, CancellationToken cancellationToken = default);
	Task UnlockUserAsync(string userId, string? unlockerId, CancellationToken cancellationToken);
	Task CreateAsync(UserForCreationDto userForCreationDto, string? userId, CancellationToken cancellationToken = default);
	Task LockUserAsync(string userId, string? lockerId, CancellationToken cancellationToken = default);
	Task<IEnumerable<AddressPreviewResponse>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default);
	Task<AddressResponse> GetAddressByIdAsync(string userId, Guid addressId,
		CancellationToken cancellationToken = default);
	Task CreateAddressAsync(string userId, AddressDto addressDto, CancellationToken cancellationToken = default);
	Task UpdateAddressAsync(string userId, Guid addressId, AddressDto addressDto, CancellationToken cancellationToken);
	Task DisableAddressAsync(string userId, Guid addressId, CancellationToken cancellationToken);
	Task<IEnumerable<UsersListResponse>> GetUsersListAsync(CancellationToken cancellationToken = default);
	Task<IEnumerable<RolesListResponse>> GetRolesListAsync(CancellationToken cancellationToken = default);
}
