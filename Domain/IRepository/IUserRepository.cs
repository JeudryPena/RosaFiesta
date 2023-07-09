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
	Task<IEnumerable<AddressEntity>> GetAddressesAsync(string userId, CancellationToken cancellationToken);
	Task<AddressEntity> GetAddressAsync(string userId, Guid addressId, CancellationToken cancellationToken);
	void CreateAddress(AddressEntity address);
	void UpdateAddress(AddressEntity address);
	Task<string> GetUserNameByIdAsync(string userId, CancellationToken cancellationToken);
	void Delete(UserEntity user);
	void DeleteAddress(AddressEntity address);
	Task<IEnumerable<RoleEntity>> GetAllRolesAsync(CancellationToken cancellationToken = default);
	Task<IEnumerable<UserEntity>> GetUsersList(CancellationToken cancellationToken = default);
	Task<IEnumerable<RoleEntity>> GetRolesList(CancellationToken cancellationToken = default);
}
