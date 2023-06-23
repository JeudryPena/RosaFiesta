using Domain.Entities.Security;
using Domain.IRepository;

using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

public class UserRepository : IUserRepository
{
	private readonly RosaFiestaContext _context;

	public UserRepository(RosaFiestaContext context) => _context = context;

	public async Task<IEnumerable<UserEntity>> GetAllAsync(
		CancellationToken cancellationToken = default
	) => await _context.Users.ToListAsync(cancellationToken);

	public async Task<UserEntity> GetByIdAsync(
		string userId,
		CancellationToken cancellationToken = default
	)
	{
		var users = await _context.Users
			.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
		if (users == null)
			throw new NullReferenceException("User not found");
		return users;
	}


	public void Insert(UserEntity user) => _context.Users.Add(user);

	public void CreateAsync(UserEntity user) =>
	_context.Users.Add(user);

	public void Update(UserEntity user) =>
	_context.Users.Update(user);

	public async Task<IEnumerable<AddressEntity>> GetAddressesAsync(string userId, CancellationToken cancellationToken)
	{
		AddressEntity? address = await _context.Addresses.FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken);
		if (address == null)
			throw new InvalidOperationException();
		return new List<AddressEntity> { address };
	}

	public async Task<AddressEntity> GetAddressAsync(string userId, Guid addressId, CancellationToken cancellationToken)
	{
		AddressEntity? address = await _context.Addresses.FirstOrDefaultAsync(x => x.UserId == userId && x.Id == addressId, cancellationToken);
		if (address == null)
			throw new NullReferenceException("Address not found");
		return address;
	}

	public void CreateAddress(AddressEntity address) => _context.Addresses.Add(address);
	public void UpdateAddress(AddressEntity address) => _context.Addresses.Update(address);

	public async Task<string?> GetUserNameByIdAsync(string userId, CancellationToken cancellationToken)
	{
		string? userName = await _context.Users.Where(x => x.Id == userId).Select(x => x.UserName).FirstOrDefaultAsync(cancellationToken);
		if (userName == null)
			return null;
		return userName;
	}
}
