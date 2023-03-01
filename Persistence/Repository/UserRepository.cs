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
    ) => await _context.Users.ToListAsync(cancellationToken);

    public async Task<UserEntity> GetByIdAsync(
        Guid userId,
        CancellationToken cancellationToken = default
    ) =>
        await _context.Users.FirstOrDefaultAsync(x => x.Id == userId.ToString(), cancellationToken) ?? throw new InvalidOperationException();

    public void Insert(UserEntity user) => _context.Users.Add(user);

    public void Delete(UserEntity user)
    {
        _context.Users.Remove(user);
    }
}
