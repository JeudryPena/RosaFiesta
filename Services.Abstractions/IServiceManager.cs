namespace Services.Abstractions;

public interface IServiceManager
{
    IOwnerService OwnerService { get; }
    IAccountService AccountService { get; }
    
    IUserService UserService { get; }
    
    IProductService ProductService { get; }
}
