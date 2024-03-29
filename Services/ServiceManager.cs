using Domain.Entities.Security;
using Domain.IRepository;

using Messaging;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

using Services.Abstractions;

namespace Services;

public sealed class ServiceManager : IServiceManager
{
	private readonly Lazy<IUserService> _lazyUserService;
	private readonly Lazy<IProductService> _lazyProductService;
	private readonly Lazy<IAuthenticateService> _lazyAuthenticateService;
	private readonly Lazy<ICategoryService> _lazyCategoryService;
	private readonly Lazy<ISupplierService> _lazySupplierService;
	private readonly Lazy<IWarrantyService> _lazyWarrantyService;
	private readonly Lazy<IDiscountService> _lazyDiscountService;
	private readonly Lazy<IPurchaseDetailService> _lazyPurchaseDetailService;
	private readonly Lazy<ICartService> _lazyCartService;
	private readonly Lazy<IReviewService> _lazyReviewService;
	private readonly Lazy<IWishListService> _lazyWishListService;
	private readonly Lazy<IOrderService> _lazyBillService;
	private readonly Lazy<IFileService> _lazyFileService;
	private readonly Lazy<IQuoteService> _lazyQuoteService;

	public ServiceManager(IRepositoryManager repositoryManager, UserManager<UserEntity> userManager, IEmailSender emailSender, IHttpContextAccessor contextAccessor, IConfiguration configuration, RoleManager<RoleEntity> roleManager)
	{
		_lazyUserService = new Lazy<IUserService>(() => new UserService(repositoryManager, userManager, roleManager));
		_lazyProductService = new Lazy<IProductService>(() => new ProductService(repositoryManager));
		_lazyAuthenticateService = new Lazy<IAuthenticateService>(() => new AuthenticateService(userManager, emailSender, contextAccessor, configuration, repositoryManager));
		_lazyCategoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager));
		_lazySupplierService = new Lazy<ISupplierService>(() => new SupplierService(repositoryManager));
		_lazyWarrantyService = new Lazy<IWarrantyService>(() => new WarrantyService(repositoryManager));
		_lazyDiscountService = new Lazy<IDiscountService>(() => new DiscountService(repositoryManager, emailSender));
		_lazyPurchaseDetailService = new Lazy<IPurchaseDetailService>(() => new PurchaseDetailService(repositoryManager));
		_lazyCartService = new Lazy<ICartService>(() => new CartService(repositoryManager));
		_lazyReviewService = new Lazy<IReviewService>(() => new ReviewService(repositoryManager));
		_lazyWishListService = new Lazy<IWishListService>(() => new WishListService(repositoryManager));
		_lazyBillService = new Lazy<IOrderService>(() => new OrderService(repositoryManager, emailSender));
		_lazyFileService = new Lazy<IFileService>(() => new FileService());
		_lazyQuoteService = new Lazy<IQuoteService>(() => new QuoteService(repositoryManager));
	}

	public IUserService UserService => _lazyUserService.Value;
	public IProductService ProductService => _lazyProductService.Value;
	public IAuthenticateService AuthenticateService => _lazyAuthenticateService.Value;
	public ICategoryService CategoryService => _lazyCategoryService.Value;
	public ISupplierService SupplierService => _lazySupplierService.Value;
	public IWarrantyService WarrantyService => _lazyWarrantyService.Value;
	public IDiscountService DiscountService => _lazyDiscountService.Value;
	public IPurchaseDetailService PurchaseDetailService => _lazyPurchaseDetailService.Value;
	public ICartService CartService => _lazyCartService.Value;
	public IReviewService ReviewService => _lazyReviewService.Value;
	public IWishListService WishListService => _lazyWishListService.Value;
	public IOrderService OrderService => _lazyBillService.Value;
	public IFileService FileService => _lazyFileService.Value;
	public IQuoteService QuoteService => _lazyQuoteService.Value;
}
