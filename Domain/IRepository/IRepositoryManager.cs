namespace Domain.IRepository;

public interface IRepositoryManager
{
    IOwnerRepository OwnerRepository { get; }

    IAccountRepository AccountRepository { get; }
    
    IUserRepository UserRepository { get; }

    IUnitOfWork UnitOfWork { get; }
    
    IProductRepository ProductRepository { get; }
}
