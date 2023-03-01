using Domain.IRepository;

namespace Persistence.Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;
    private readonly Lazy<IUserRepository> _lazyUserRepository;
    private readonly Lazy<IProductRepository> _lazyProductRepository;

    public RepositoryManager(RosaFiestaContext dbContext)
    {
        _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        _lazyUserRepository = new Lazy<IUserRepository>(() => new UserRepository(dbContext));
        _lazyProductRepository = new Lazy<IProductRepository>(() => new ProductRepository(dbContext));
    }

    public IUserRepository UserRepository => _lazyUserRepository.Value;
    public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    
    public IProductRepository ProductRepository => _lazyProductRepository.Value;
}