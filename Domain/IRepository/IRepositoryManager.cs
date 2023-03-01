namespace Domain.IRepository;

public interface IRepositoryManager
{
    IUserRepository UserRepository { get; }

    IUnitOfWork UnitOfWork { get; }
    
    IProductRepository ProductRepository { get; }
}
