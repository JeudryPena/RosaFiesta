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

	public async Task UpdateAsync(string updaterId, string userId, UserForCreationDto userForUpdateDto,
		CancellationToken cancellationToken = default)
	{
		await _repositoryManager.UserRepository.VerifyUserAlredyExistsAsync(userForUpdateDto.UserName, userId, cancellationToken);
		await _repositoryManager.UserRepository.VerifyEmailAlredyExistsAsync(userForUpdateDto.Email, userId, cancellationToken);
		UserEntity user = await _repositoryManager.UserRepository.GetByIdAsync(
			userId,
			cancellationToken
		) ?? throw new UserNotFoundException(userId);
		user = userForUpdateDto.Adapt(user);
		if (user.BirthDate.AddYears(18) > DateOnly.FromDateTime(DateTime.UtcNow))
			throw new InvalidOperationException("El usuario debe ser mayor de 18 años");
		user.UpdatedAt = DateTimeOffset.UtcNow;
		user.UpdatedBy = updaterId;
		await _userManager.UpdateAsync(user);
		foreach (var rol in userForUpdateDto.RolesId)
		{
			IList<string> roles = await _userManager.GetRolesAsync(user);
			foreach (var oldRole in roles)
			{
				await _userManager.RemoveFromRoleAsync(user, oldRole);
			}
			var role = await _roleManager.FindByIdAsync(rol.RoleId);
			if (role == null)
				throw new NullReferenceException(rol.RoleId);
			var result = await _userManager.AddToRoleAsync(user, role.Name);
			if (!result.Succeeded)
				IdentityResultMessage(result);
		}
		await _repositoryManager.UnitOfWork.SaveChangesAsync(updaterId, cancellationToken);
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
		await _repositoryManager.UserRepository.VerifyIfUserAlredyExistsAsync(userForCreationDto.UserName, cancellationToken);
		await _repositoryManager.UserRepository.VerifyIfEmailAlredyExistsAsync(userForCreationDto.Email, cancellationToken);
		UserEntity user = userForCreationDto.Adapt<UserEntity>();
		user.EmailConfirmed = true;
		user.LockoutEnabled = true;
		user.LockoutEnd = null;
		user.AccessFailedCount = 0;
		user.SecurityStamp = Guid.NewGuid().ToString();
		user.Cart = new();
		user.WishList = new WishListEntity { Id = Guid.NewGuid() };
		user.CreatedAt = DateTimeOffset.UtcNow;
		user.CreatedBy = userId;
		if (user.BirthDate.AddYears(18) > DateOnly.FromDateTime(DateTime.UtcNow))
			throw new InvalidOperationException("El usuario debe ser mayor de 18 años");
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

	/// <summary>
	/// Change promotional emails status
	/// </summary>
	/// <param name="userId"></param>
	/// <param name="cancellationToken"></param>
	public async Task ChangePromotionalEmailsAsync(string userId, CancellationToken cancellationToken)
	{
		UserEntity user = await _repositoryManager.UserRepository.GetByIdAsync(userId, cancellationToken);
		user.PromotionalMails = !user.PromotionalMails;
		_repositoryManager.UserRepository.Update(user);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}

	/// <summary>
	/// Delete my user
	/// </summary>
	/// <param name="userId"></param>
	/// <param name="cancellationToken"></param>
	public async Task DeleteMyUserAsync(string userId, CancellationToken cancellationToken)
	{
		UserEntity user = await _repositoryManager.UserRepository.GetByIdAsync(userId, cancellationToken);
		_repositoryManager.UserRepository.Delete(user);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}
}
