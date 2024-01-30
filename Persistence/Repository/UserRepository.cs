using Domain.Entities.Security;
using Domain.IRepository;

using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

public class UserRepository : IUserRepository
{
	private readonly RosaFiestaContext _context;

	public UserRepository(RosaFiestaContext context) => _context = context;

	public async Task<IEnumerable<UserEntity>> GetUsersList(CancellationToken cancellationToken = default) => await _context.Users.ToListAsync(cancellationToken);

	public async Task<IEnumerable<UserEntity>> GetAllAsync(
		CancellationToken cancellationToken = default
	) => await _context.Users.Include(x => x.UserRoles).ThenInclude(x => x.Role).ToListAsync(cancellationToken);

	public async Task<UserEntity> GetByIdAsync(
		string userId,
		CancellationToken cancellationToken = default
	)
	{
		var users = await _context.Users.Include(x => x.UserRoles).ThenInclude(x => x.Role)
			.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
		return users;
	}

	public async Task<IEnumerable<RoleEntity>> GetAllRolesAsync(CancellationToken cancellationToken = default)
	{
		IEnumerable<RoleEntity> roles = await _context.Roles.ToListAsync(cancellationToken);
		return roles;
	}

	public void Insert(UserEntity user) => _context.Users.Add(user);

	public void CreateAsync(UserEntity user) =>
	_context.Users.Add(user);

	public void Update(UserEntity user) =>
	_context.Users.Update(user);

	public async Task<string> GetUserName(string userId, CancellationToken cancellationToken)
	{
		string? userName = await _context.Users.Where(x => x.Id == userId).Select(x => x.UserName).FirstOrDefaultAsync(cancellationToken);
		if (userName == null)
			return "";
		return userName;
	}

	public void Delete(UserEntity user)
	=> _context.Users.Remove(user);

	public async Task<IEnumerable<RoleEntity>> GetRolesList(CancellationToken cancellationToken = default) => await _context.Roles.ToListAsync(cancellationToken);
	public async Task VerifyUserAlredyExistsAsync(string username, string userId, CancellationToken cancellationToken)
	{
		bool userExists = await _context.Users.AnyAsync(x => x.UserName == username && x.Id != userId, cancellationToken);
		if (userExists)
			 throw new Exception("Ya existe un usuario con ese nuevo nombre de usuario");
	}

	public async Task VerifyEmailAlredyExistsAsync(string email, string userId, CancellationToken cancellationToken)
	{
		bool emailExists = await _context.Users.AnyAsync(x => x.Email == email && x.Id != userId, cancellationToken);
		if (emailExists)
			throw new Exception("Ya existe un usuario con ese nuevo correo electrónico");
	}

	public async Task VerifyIfUserAlredyExistsAsync(string userName, CancellationToken cancellationToken)
	{
		bool userExists = await _context.Users.AnyAsync(x => x.UserName == userName, cancellationToken);
		if(userExists)
			throw new Exception("Ya existe un usuario con ese nombre de usuario");
	}

	public async Task VerifyIfEmailAlredyExistsAsync(string email, CancellationToken cancellationToken)
	{
		bool emailExists = await _context.Users.AnyAsync(x => x.Email == email, cancellationToken);
		if (emailExists)
			throw new Exception("Ya existe un usuario con ese correo electrónico");
	}

	public async Task<List<string>> GetAdminEmails(CancellationToken cancellationToken)
	{
		List<string> adminEmails = await _context.Users.Where(x => x.UserRoles.Any(x => x.Role.Name == "Admin" || x.Role.Name == "SalesManager")).Select(x => x.Email).ToListAsync(cancellationToken);
		return adminEmails;
	}

	public async Task<List<string>> GetAllUsersWithPromoEnabled(CancellationToken cancellationToken)
	{
		List<string> emails = await _context.Users.Where(x => x.PromotionalMails).Select(x => x.Email).ToListAsync(cancellationToken);
		return emails;
	}

	public async Task<int> GetTotalClientsWithDatesAsync(CancellationToken cancellationToken, DateOnly start, DateOnly end)
	{
		int totalClients = await _context.Users.Where(x => DateOnly.FromDateTime(x.CreatedAt.Date) >= start && DateOnly.FromDateTime(x.CreatedAt.Date) <= end && x.Orders != null && x.Orders.Count > 0).CountAsync(cancellationToken);
		return totalClients;
	}

	public async Task<string> GetUserEmail(string userId, CancellationToken cancellationToken)
	{
		string? email = await _context.Users.Where(x => x.Id == userId).Select(x => x.Email).FirstOrDefaultAsync(cancellationToken);
		if (email == null)
			throw new Exception("User not found");
		return email;
	}
}
