using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface IServiceManager
{
    IUserService UserService { get; }
    
    IProductService ProductService { get; }
    
    IAuthenticateService AuthenticateService { get; }
    
    ICategoryService CategoryService { get; }
    
    ISupplierService SupplierService { get; }
    
    IWarrantyService WarrantyService { get; }
    
    IDiscountService DiscountService { get; }
    
    IPurchaseDetailService PurchaseDetailService { get; }
    
    ICartService CartService { get; }
    
    IPayMethodService PayMethodService { get; }
    
    IReviewService ReviewService { get; }
    
    IWishListService WishListService { get; }
    
    IOrderService OrderService { get; }
    
    IFileService FileService { get; }
}
