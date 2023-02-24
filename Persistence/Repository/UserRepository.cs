using Domain.Entities;
using Domain.IRepository;

namespace Persistence.Repository;

public class UserRepository : IUserRepository
{
    private readonly RosaFiestaContext _context;

    public UserRepository(RosaFiestaContext context)
    {
        _context = context;
    }
    
    public void Insert(UserEntity user)
    {
        _context.Users.Add(user);
    }
}
