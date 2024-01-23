using Domain.Entities.Product;

namespace Domain.IRepository;

public interface IProductRepository
{
	void Insert(ProductEntity product);
	Task<IEnumerable<ProductEntity>> GetAllAsync(CancellationToken cancellationToken = default);
	Task<IEnumerable<ProductEntity>> ManagementGetAllAsync(CancellationToken cancellationToken = default);
	Task<ProductEntity> GetByIdAsync(Guid productId,
		CancellationToken cancellationToken = default);
	Task<OptionEntity> GetOptionByIdAsync(Guid optionId, CancellationToken cancellationToken = default);
	void Update(ProductEntity product);
	Task<ProductEntity> GetProductDetail(Guid cartItemProductId, Guid optionId,
		CancellationToken cancellationToken = default);
	Task<ProductEntity> GetProductAndOption(Guid productCode, Guid optionId, CancellationToken cancellationToken = default);
	Task<ProductEntity> GetProductById(Guid productId, CancellationToken cancellationToken = default);
	void UpdateOption(OptionEntity option);
	void DeleteOption(OptionEntity option);
	void Delete(ProductEntity product);
	Task<string> GetOptionTitle(Guid optionId, CancellationToken cancellationToken);
	Task<List<string>> GetOptionImages(Guid optionId, CancellationToken cancellationToken);
	Task<IEnumerable<ProductEntity>> GetProductsList(CancellationToken cancellationToken = default);
	void InsertOptions(ICollection<OptionEntity> options);
	void InsertOptionImages(IList<MultipleOptionImagesEntity> images);
	Task<ProductEntity> GetProductWithOption(Guid id, CancellationToken cancellationToken);
	Task<IEnumerable<OptionEntity>> GetOptionsList(CancellationToken cancellationToken = default);
	Task<ProductEntity> GetDetailAsync(Guid id, Guid optionId, CancellationToken cancellationToken = default);
	Task<double> CartItemPrice(Guid optionId, int quantity, CancellationToken cancellationToken = default);
	Task CheckOptionAviabilityAsync(Guid optionId, int quantity, CancellationToken cancellationToken = default);
	
	/// <summary>
	/// Get all recommended products
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<IEnumerable<ProductEntity>> GetAllRecommendedAsync(CancellationToken cancellationToken);

	/// <summary>
	/// Search products
	/// </summary>
	/// <param name="search"></param>
	/// <param name="filter"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<IEnumerable<ProductEntity>> FilterProductsAsync(SearchFilter filter,
		CancellationToken cancellationToken);

	/// <summary>
	/// Retrieves related products
	/// </summary>
	/// <param name="categoryId"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<IEnumerable<ProductEntity>> GetRelatedProducts(int categoryId, CancellationToken cancellationToken);
	
	/// <summary>
	/// Retrieves searched products
	/// </summary>
	/// <param name="filter"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<IEnumerable<ProductEntity>> SearchProductsAsync(ProductsSearch filter, CancellationToken cancellationToken);

	Task<bool> IsService(Guid optionProductId, CancellationToken cancellationToken);
	Task<int> GetCountViews(CancellationToken cancellationToken);
	Task<IEnumerable<MostPurchasedProducts>> GetMostPurchasedProductsAsync(CancellationToken cancellationToken);
}