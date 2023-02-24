using Domain.IRepository;

namespace Persistence.Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IOwnerRepository> _lazyOwnerRepository;
    private readonly Lazy<IAccountRepository> _lazyAccountRepository;
    private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;
    private readonly Lazy<IUserRepository> _lazyUserRepository;
    private readonly Lazy<IProductRepository> _lazyProductRepository;

    public RepositoryManager(RosaFiestaContext dbContext)
    {
        _lazyOwnerRepository = new Lazy<IOwnerRepository>(() => new OwnerRepository(dbContext));
        _lazyAccountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(dbContext));
        _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        _lazyUserRepository = new Lazy<IUserRepository>(() => new UserRepository(dbContext));
        _lazyProductRepository = new Lazy<IProductRepository>(() => new ProductRepository(dbContext));
    }

    public IOwnerRepository OwnerRepository => _lazyOwnerRepository.Value;

    public IAccountRepository AccountRepository => _lazyAccountRepository.Value;
    
    public IUserRepository UserRepository => _lazyUserRepository.Value;
    public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    
    public IProductRepository ProductRepository => _lazyProductRepository.Value;
}