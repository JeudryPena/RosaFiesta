namespace Domain.IRepository;

public interface IRepositoryManager
{
	IUserRepository UserRepository { get; }
	IUnitOfWork UnitOfWork { get; }
	IProductRepository ProductRepository { get; }
	ICategoryRepository CategoryRepository { get; }
	ISupplierRepository SupplierRepository { get; }
	IWarrantyRepository WarrantyRepository { get; }
	IDiscountRepository DiscountRepository { get; }
	IPurchaseDetailRepository PurchaseDetailRepository { get; }
	ICartRepository CartRepository { get; }
	IWishListRepository WishListRepository { get; }
	IReviewRepository ReviewRepository { get; }
	IOrderRepository OrderRepository { get; }
	IPayMethodRepository PayMethodRepository { get; }
	IQuoteRepository QuoteRepository { get; }
	IServiceRepository ServiceRepository { get; }
}
