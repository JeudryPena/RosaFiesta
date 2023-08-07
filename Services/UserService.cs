using Contracts.Model.Security;
using Contracts.Model.Security.Response;

using Domain.Entities.Security;
using Domain.Exceptions;
using Domain.IRepository;

using Mapster;

using Microsoft.AspNetCore.Identity;

using Services.Abstractions;

namespace Services;

internal sealed class UserService : IUserService
{
	private readonly IRepositoryManager _repositoryManager;
	private readonly UserManager<UserEntity> _userManager;
	private readonly RoleManager<RoleEntity> _roleManager;
	public UserService(IRepositoryManager repositoryManager, UserManager<UserEntity> userManager, RoleManager<RoleEntity> roleManager)
	{
		_repositoryManager = repositoryManager;
		_userManager = userManager;
		_roleManager = roleManager;
	}

	public async Task<IEnumerable<ManagementUsersResponse>> GetAllUserAsync(
		CancellationToken cancellationToken = default
	)
	{
		IEnumerable<UserEntity> users = await _repositoryManager.UserRepository.GetAllAsync(
			cancellationToken
		);
		foreach (UserEntity user in users)
		{
			user.CreatedBy = await _repositoryManager.UserRepository.GetUserName(user.CreatedBy, cancellationToken);
			if (user.UpdatedBy != null)
				user.UpdatedBy = await _repositoryManager.UserRepository.GetUserName(user.UpdatedBy, cancellationToken);
		}
		IEnumerable<ManagementUsersResponse>? usersDto = users.Adapt<IEnumerable<ManagementUsersResponse>>();
		return usersDto;
	}

	public async Task<UserResponse> GetUserByIdAsync(
		string userId,
		CancellationToken cancellationToken = default
	)
	{
		UserEntity user = await _repositoryManager.UserRepository.GetByIdAsync(
			userId,
			cancellationToken
		) ?? throw new UserNotFoundException(userId.ToString());
		UserResponse usersResponse = user.Adapt<UserResponse>();
		usersResponse.CreatedBy = await _repositoryManager.UserRepository.GetUserName(user.CreatedBy, cancellationToken);
		if (user.UpdatedBy != null)
			usersResponse.UpdatedBy = await _repositoryManager.UserRepository.GetUserName(user.UpdatedBy, cancellationToken);
		return usersResponse;
	}

	public async Task UpdateAsync(string? username, string userId, UserForCreationDto userForUpdateDto,
		CancellationToken cancellationToken = default)
	{
		UserEntity user = await _repositoryManager.UserRepository.GetByIdAsync(
			userId,
			cancellationToken
		) ?? throw new UserNotFoundException(userId);
		user = userForUpdateDto.Adapt(user);
		_repositoryManager.UserRepository.Update(user);
		IEnumerable<string> newRoles = new List<string>();
		foreach (var rol in userForUpdateDto.RolesId)
		{
			var role = await _roleManager.FindByIdAsync(rol.RoleId);
			if (role == null)
				throw new NullReferenceException(rol.RoleId);
			newRoles.Append(role.Name);
		}
		var currentRoles = await _userManager.GetRolesAsync(user);
		var rolesToRemove = currentRoles.Except(newRoles).ToList();
		foreach (var role in rolesToRemove)
			await _userManager.RemoveFromRoleAsync(user, role);
		var rolesToAdd = newRoles.Except(currentRoles).ToList();
		foreach (var role in rolesToAdd)
			await _userManager.AddToRoleAsync(user, role);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task DeleteAsync(string userId, CancellationToken cancellationToken = default)
	{
		UserEntity user = await _repositoryManager.UserRepository.GetByIdAsync(
			userId,
			cancellationToken
		) ?? throw new UserNotFoundException(userId.ToString());
		_repositoryManager.UserRepository.Delete(user);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task UnlockUserAsync(string userId, string? username, CancellationToken cancellationToken)
	{
		UserEntity user = await _repositoryManager.UserRepository.GetByIdAsync(
			userId,
			cancellationToken
		) ?? throw new UserNotFoundException(userId.ToString());

		user.LockoutEnd = null;
		user.AccessFailedCount = 0;
		_repositoryManager.UserRepository.Update(user);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task CreateAsync(UserForCreationDto userForCreationDto, string userId, CancellationToken cancellationToken = default)
	{
		UserEntity user = userForCreationDto.Adapt<UserEntity>();
		user.EmailConfirmed = true;
		user.LockoutEnabled = true;
		user.LockoutEnd = null;
		user.AccessFailedCount = 0;
		user.SecurityStamp = Guid.NewGuid().ToString();
		user.Cart = new();
		var result = await _userManager.CreateAsync(user, userForCreationDto.Password);
		if (!result.Succeeded)
			IdentityResultMessage(result);
		foreach (var rol in userForCreationDto.RolesId)
		{
			var role = await _roleManager.FindByIdAsync(rol.RoleId);
			if (role == null)
				throw new NullReferenceException(rol.RoleId);
			result = await _userManager.AddToRoleAsync(user, role.Name);
			if (!result.Succeeded)
				IdentityResultMessage(result);
		}
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	private void IdentityResultMessage(IdentityResult result)
	{
		if (!result.Succeeded)
		{
			var errors = result.Errors.Select(e => e.Description);
			throw new InvalidOperationException(string.Join(", ", errors));
		}
	}

	public async Task LockUserAsync(string userId, string? username, CancellationToken cancellationToken = default)
	{
		UserEntity user = await _repositoryManager.UserRepository.GetByIdAsync(
			userId,
			cancellationToken
		) ?? throw new UserNotFoundException(userId);

		user.LockoutEnd = DateTimeOffset.UtcNow.AddYears(100);
		user.AccessFailedCount = 0;
		_repositoryManager.UserRepository.Update(user);

		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	public async Task<IEnumerable<AddressPreviewResponse>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default)
	{
		IEnumerable<AddressEntity> addresses = await _repositoryManager.UserRepository.GetAddressesAsync(
			userId,
			cancellationToken
		);
		var addressesDto = addresses.Adapt<IEnumerable<AddressPreviewResponse>>();
		return addressesDto;
	}

	public async Task<AddressResponse> GetAddressByIdAsync(string userId, Guid addressId, CancellationToken cancellationToken = default)
	{
		AddressEntity address = await _repositoryManager.UserRepository.GetAddressAsync(
			userId,
			addressId,
			cancellationToken
		);
		AddressResponse addressDto = address.Adapt<AddressResponse>();
		return addressDto;
	}

	public async Task CreateAddressAsync(string userId, AddressDto addressDto, CancellationToken cancellationToken = default)
	{
		AddressEntity address = addressDto.Adapt<AddressEntity>();
		address.UserId = userId;
		_repositoryManager.UserRepository.CreateAddress(address);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(null, cancellationToken);
	}

	public async Task UpdateAddressAsync(string userId, Guid addressId, AddressDto addressDto, CancellationToken cancellationToken)
	{
		AddressEntity address = await _repositoryManager.UserRepository.GetAddressAsync(userId, addressId, cancellationToken);
		address = addressDto.Adapt(address);
		_repositoryManager.UserRepository.UpdateAddress(address);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(null, cancellationToken);
	}

	public async Task DisableAddressAsync(string userId, Guid addressId, CancellationToken cancellationToken)
	{
		AddressEntity address = await _repositoryManager.UserRepository.GetAddressAsync(userId, addressId, cancellationToken);
		_repositoryManager.UserRepository.DeleteAddress(address);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(null, cancellationToken);
	}

	public async Task<IEnumerable<UsersListResponse>> GetUsersListAsync(CancellationToken cancellationToken = default)
	{
		IEnumerable<UserEntity> users = await _repositoryManager.UserRepository.GetUsersList(cancellationToken);
		var usersDto = users.Adapt<IEnumerable<UsersListResponse>>();
		return usersDto;
	}

	public async Task<IEnumerable<RolesListResponse>> GetRolesListAsync(CancellationToken cancellationToken = default)
	{
		IEnumerable<RoleEntity> roles = await _repositoryManager.UserRepository.GetRolesList(cancellationToken);
		var rolesResponse = roles.Adapt<IEnumerable<RolesListResponse>>();
		return rolesResponse;
	}

	public async Task<string> GetUserName(string userId, CancellationToken cancellationToken)
	{
		string userName = await _repositoryManager.UserRepository.GetUserName(userId, cancellationToken);
		return userName;
	}
}
