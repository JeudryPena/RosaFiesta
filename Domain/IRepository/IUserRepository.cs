using Domain.Entities;

namespace Domain.IRepository;

public interface IUserRepository
{
    void Insert(UserEntity user);
}
