using Domain.IRepository;

namespace Persistence.Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;
    private readonly Lazy<IUserRepository> _lazyUserRepository;
    private readonly Lazy<IProductRepository> _lazyProductRepository;
    private readonly Lazy<ICategoryRepository> _lazyCategoryRepository;
    private readonly Lazy<ISupplierRepository> _lazySupplierRepository;
    private readonly Lazy<IWarrantyRepository> _lazyWarrantyRepository;
    private readonly Lazy<IDiscountRepository> _lazyDiscountRepository;
    private readonly Lazy<IPurchaseDetailRepository> _lazyPurchaseDetailRepository;
    private readonly Lazy<ICartRepository> _lazyCartRepository;
    private readonly Lazy<IWishListRepository> _lazyWishRepository;
    private readonly Lazy<IReviewRepository> _lazyReviewRepository;
    private readonly Lazy<IOrderRepository> _lazyBillRepository;
    private readonly Lazy<IPayMethodRepository> _lazyPayMethodRepository;
    private readonly Lazy<IActionLogRepository> _lazyActionLogRepository;
    private readonly Lazy<IQuoteRepository> _lazyQuoteRepository;
    private readonly Lazy<IServiceRepository> _lazyServiceRepository;

    public RepositoryManager(RosaFiestaContext dbContext)
    {
        _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        _lazyUserRepository = new Lazy<IUserRepository>(() => new UserRepository(dbContext));
        _lazyProductRepository = new Lazy<IProductRepository>(() => new ProductRepository(dbContext));
        _lazyCategoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(dbContext));
        _lazySupplierRepository = new Lazy<ISupplierRepository>(() => new SupplierRepository(dbContext));
        _lazyWarrantyRepository = new Lazy<IWarrantyRepository>(() => new WarrantyRepository(dbContext));
        _lazyDiscountRepository = new Lazy<IDiscountRepository>(() => new DiscountRepository(dbContext));
        _lazyPurchaseDetailRepository = new Lazy<IPurchaseDetailRepository>(() => new PurchaseDetailRepository(dbContext));
        _lazyCartRepository = new Lazy<ICartRepository>(() => new CartRepository(dbContext));
        _lazyWishRepository = new Lazy<IWishListRepository>(() => new WishListRepository(dbContext));
        _lazyReviewRepository = new Lazy<IReviewRepository>(() => new ReviewRepository(dbContext));
        _lazyBillRepository = new Lazy<IOrderRepository>(() => new OrderRepository(dbContext));
        _lazyPayMethodRepository = new Lazy<IPayMethodRepository>(() => new PayMethodRepository(dbContext));
        _lazyActionLogRepository = new Lazy<IActionLogRepository>(() => new ActionLogRepository(dbContext));
        _lazyQuoteRepository = new Lazy<IQuoteRepository>(() => new QuoteRepository(dbContext));
        _lazyServiceRepository = new Lazy<IServiceRepository>(() => new ServiceRepository(dbContext));
    }

    public IUserRepository UserRepository => _lazyUserRepository.Value;
    public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    public IProductRepository ProductRepository => _lazyProductRepository.Value;
    public ICategoryRepository CategoryRepository => _lazyCategoryRepository.Value;
    public ISupplierRepository SupplierRepository => _lazySupplierRepository.Value;
    public IWarrantyRepository WarrantyRepository => _lazyWarrantyRepository.Value;
    public IDiscountRepository DiscountRepository => _lazyDiscountRepository.Value;
    public IPurchaseDetailRepository PurchaseDetailRepository => _lazyPurchaseDetailRepository.Value;
    public ICartRepository CartRepository => _lazyCartRepository.Value;
    public IWishListRepository WishListRepository => _lazyWishRepository.Value;
    public IReviewRepository ReviewRepository => _lazyReviewRepository.Value;
    public IOrderRepository OrderRepository => _lazyBillRepository.Value;
    public IPayMethodRepository PayMethodRepository => _lazyPayMethodRepository.Value;
    public IActionLogRepository ActionLogRepository => _lazyActionLogRepository.Value;
    public IQuoteRepository QuoteRepository => _lazyQuoteRepository.Value;
    public IServiceRepository ServiceRepository => _lazyServiceRepository.Value;
}