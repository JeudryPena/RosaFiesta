using Contracts.Model.Security;
using Contracts.Model.Security.Response;

using Domain.Entities.Product.UserInteract;
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

	public UserService(IRepositoryManager repositoryManager)
	{
		_repositoryManager = repositoryManager;
	}

	public async Task<string> GetUserNameByIdAsync(string userId, CancellationToken cancellationToken = default)
	{
		string userName = await _repositoryManager.UserRepository.GetUserNameByIdAsync(userId, cancellationToken);
		return userName;
	}

	public async Task<IEnumerable<ManagementUsersResponse>> GetAllUserAsync(
		CancellationToken cancellationToken = default
	)
	{
		IEnumerable<UserEntity> users = await _repositoryManager.UserRepository.GetAllAsync(
			cancellationToken
		);
		IEnumerable<ManagementUsersResponse>? usersDto = users.Adapt<IEnumerable<ManagementUsersResponse>>();
		return usersDto;
	}

	public async Task<UsersResponse> GetUserByIdAsync(
		string userId,
		CancellationToken cancellationToken = default
	)
	{
		UserEntity user = await _repositoryManager.UserRepository.GetByIdAsync(
			userId,
			cancellationToken
		) ?? throw new UserNotFoundException(userId.ToString());
		UsersResponse usersResponse = user.Adapt<UsersResponse>();
		return usersResponse;
	}

	public async Task UpdateAsync(string? username, string userId, UserForUpdateDto userForUpdateDto,
		CancellationToken cancellationToken = default)
	{
		UserEntity user = await _repositoryManager.UserRepository.GetByIdAsync(
			userId,
			cancellationToken
		) ?? throw new UserNotFoundException(userId);

		user.FullName = userForUpdateDto.Name + " " + userForUpdateDto.LastName;
		user.BirthDate = userForUpdateDto.BirthDate;
		_repositoryManager.UserRepository.Update(user);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
	}

	public async Task DeleteAsync(string userId, CancellationToken cancellationToken = default)
	{
		UserEntity user = await _repositoryManager.UserRepository.GetByIdAsync(
			userId,
			cancellationToken
		) ?? throw new UserNotFoundException(userId.ToString());
		user.IsDeleted = true;
		_repositoryManager.UserRepository.Update(user);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
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
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
	}

	public async Task<UsersResponse> CreateAsync(UserForCreationDto userForCreationDto, string? username, CancellationToken cancellationToken = default)
	{
		UserEntity user = userForCreationDto.Adapt<UserEntity>();
		user.FullName = userForCreationDto.Name + " " + userForCreationDto.LastName;
		user.CreatedAt = DateTimeOffset.UtcNow;
		user.UserName = userForCreationDto.Email;
		user.Email = userForCreationDto.Email;
		user.EmailConfirmed = true;
		user.LockoutEnabled = true;
		user.LockoutEnd = null;
		user.AccessFailedCount = 0;
		user.NormalizedEmail = userForCreationDto.Email.ToUpper();
		user.NormalizedUserName = userForCreationDto.Email.ToUpper();
		user.SecurityStamp = Guid.NewGuid().ToString();
		user.PasswordHash = new PasswordHasher<UserEntity>().HashPassword(user, userForCreationDto.Password);
		user.Cart = new CartEntity();

		_repositoryManager.UserRepository.CreateAsync(user);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

		UsersResponse usersResponse = user.Adapt<UsersResponse>();
		return usersResponse;
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

		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
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

	public async Task<AddressResponse> CreateAddressAsync(string userId, AddressDto addressDto, CancellationToken cancellationToken = default)
	{
		AddressEntity address = addressDto.Adapt<AddressEntity>();
		address.UserId = userId;
		address.CreatedAt = DateTimeOffset.UtcNow;
		address.UpdatedAt = DateTimeOffset.UtcNow;
		_repositoryManager.UserRepository.CreateAddress(address);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
		AddressResponse addressResponse = address.Adapt<AddressResponse>();
		return addressResponse;
	}

	public async Task<AddressResponse> UpdateAddressAsync(string userId, Guid addressId, AddressDto addressDto, CancellationToken cancellationToken)
	{
		AddressEntity address = await _repositoryManager.UserRepository.GetAddressAsync(userId, addressId, cancellationToken);
		address = addressDto.Adapt(address);
		address.UpdatedAt = DateTimeOffset.UtcNow;
		_repositoryManager.UserRepository.UpdateAddress(address);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
		AddressResponse addressResponse = address.Adapt<AddressResponse>();
		return addressResponse;
	}

	public async Task DisableAddressAsync(string userId, Guid addressId, CancellationToken cancellationToken)
	{
		AddressEntity address = await _repositoryManager.UserRepository.GetAddressAsync(userId, addressId, cancellationToken);
		address.IsDeleted = true;
		address.UpdatedAt = DateTimeOffset.UtcNow;
		_repositoryManager.UserRepository.UpdateAddress(address);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
	}
}
