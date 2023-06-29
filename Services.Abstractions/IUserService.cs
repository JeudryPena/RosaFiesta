using Contracts.Model.Security;
using Contracts.Model.Security.Response;

namespace Services.Abstractions;

public interface IUserService
{
	Task<IEnumerable<ManagementUsersResponse>> GetAllUserAsync(CancellationToken cancellationToken = default);
	Task<UsersResponse> GetUserByIdAsync(string userId, CancellationToken cancellationToken = default);
	Task UpdateAsync(string? username, string userId, UserForUpdateDto userForUpdateDto,
		CancellationToken cancellationToken = default);
	Task DeleteAsync(string userId, CancellationToken cancellationToken = default);
	Task UnlockUserAsync(string userId, string? username, CancellationToken cancellationToken);
	Task CreateAsync(UserForCreationDto userForCreationDto, string? userId, CancellationToken cancellationToken = default);
	Task LockUserAsync(string userId, string? username, CancellationToken cancellationToken = default);
	Task<IEnumerable<AddressPreviewResponse>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default);
	Task<AddressResponse> GetAddressByIdAsync(string userId, Guid addressId,
		CancellationToken cancellationToken = default);
	Task<AddressResponse> CreateAddressAsync(string userId, AddressDto addressDto, CancellationToken cancellationToken = default);
	Task<AddressResponse> UpdateAddressAsync(string userId, Guid addressId, AddressDto addressDto, CancellationToken cancellationToken);
	Task DisableAddressAsync(string userId, Guid addressId, CancellationToken cancellationToken);
	Task<string?> GetUserNameByIdAsync(string userId, CancellationToken cancellationToken = default);
	Task<IEnumerable<RolesResponse>> GetAllRolesAsync(CancellationToken cancellationToken = default);
}
