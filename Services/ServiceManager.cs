using Domain.Entities;
using Domain.Entities.Security;
using Domain.IRepository;
using Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Services.Abstractions;

namespace Services;

public sealed class ServiceManager: IServiceManager
{
    private readonly Lazy<IUserService> _lazyUserService;
    private readonly Lazy<IProductService> _lazyProductService;
    private readonly Lazy<IAuthenticateService> _lazyAuthenticateService;

    public ServiceManager(IRepositoryManager repositoryManager, UserManager<UserEntity> userManager, IEmailSender emailSender, IHttpContextAccessor contextAccessor, SignInManager<UserEntity> signInManager, IConfiguration configuration)
    {
        _lazyUserService = new Lazy<IUserService>(() => new UserService(repositoryManager));
        _lazyProductService = new Lazy<IProductService>(() => new ProductService(repositoryManager));
        _lazyAuthenticateService = new Lazy<IAuthenticateService>(() => new AuthenticateService(userManager, emailSender, contextAccessor, signInManager, configuration));
    }

    public IUserService UserService => _lazyUserService.Value;
    
    public IProductService ProductService => _lazyProductService.Value;
    
    public IAuthenticateService AuthenticateService => _lazyAuthenticateService.Value;
}
