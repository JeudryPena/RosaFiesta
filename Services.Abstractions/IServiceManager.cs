namespace Services.Abstractions;

public interface IServiceManager
{
    IUserService UserService { get; }
    
    IProductService ProductService { get; }
    
    IAuthenticateService AuthenticateService { get; }
}
