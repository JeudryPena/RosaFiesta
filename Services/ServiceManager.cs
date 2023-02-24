using Domain.Entities;
using Domain.IRepository;
using Microsoft.AspNetCore.Identity;
using Services.Abstractions;

namespace Services;

public sealed class ServiceManager: IServiceManager
{
    private readonly Lazy<IOwnerService> _lazyOwnerService;
    private readonly Lazy<IAccountService> _lazyAccountService;
    private readonly Lazy<IUserService> _lazyUserService;
    private readonly Lazy<IProductService> _lazyProductService;

    public ServiceManager(IRepositoryManager repositoryManager, UserManager<UserEntity> userManager)
    {
         
        _lazyOwnerService = new Lazy<IOwnerService>(() => new OwnerService(repositoryManager));
        _lazyAccountService = new Lazy<IAccountService>(() => new AccountService(repositoryManager));
        _lazyUserService = new Lazy<IUserService>(() => new UserService(repositoryManager, userManager));
        _lazyProductService = new Lazy<IProductService>(() => new ProductService(repositoryManager));
    }
    
    public IOwnerService OwnerService => _lazyOwnerService.Value;
    public IAccountService AccountService => _lazyAccountService.Value;
    
    public IUserService UserService => _lazyUserService.Value;
    
    public IProductService ProductService => _lazyProductService.Value;
}
