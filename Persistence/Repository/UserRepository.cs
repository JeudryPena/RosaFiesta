using Domain.Entities;
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
    ) => await _context.Users.Include(x => x.Orders).Include( x => x.WishLists).Include(x => x.Reviews).Include(x => x.AppliedDiscounts).ToListAsync(cancellationToken);

    public async Task<UserEntity> GetByIdAsync(
        string userId,
        CancellationToken cancellationToken = default
    ) =>
        await _context.Users.Include(x => x.Orders).Include( x => x.WishLists).Include(x => x.Reviews).Include(x => x.AppliedDiscounts)
            .FirstOrDefaultAsync(x => x.Id == userId, cancellationToken) ?? throw new InvalidOperationException();

    public void Insert(UserEntity user) => _context.Users.Add(user);

    public void Delete(UserEntity user) =>
    _context.Users.Remove(user);
    
    public void CreateAsync(UserEntity user) =>
    _context.Users.Add(user);
    
    public void Update(UserEntity user) =>
    _context.Users.Update(user);

    public async Task<IEnumerable<AddressEntity>> GetAddressesAsync(string userId, CancellationToken cancellationToken)
    {
        AddressEntity? address = await _context.Addresses.FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken);
        if (address == null)
            throw new InvalidOperationException();
        return new List<AddressEntity> {address};
    }

    public async Task<AddressEntity> GetAddressAsync(string userId, Guid addressId, CancellationToken cancellationToken)
    {
        AddressEntity? address = await _context.Addresses.FirstOrDefaultAsync(x => x.UserId == userId && x.Id == addressId, cancellationToken);
        if (address == null)
            throw new InvalidOperationException();
        return address;
    }
}
