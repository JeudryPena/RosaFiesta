using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface IProductService
{
	Task<ICollection<ProductPreviewResponse>> GetAllAsyncPreview(CancellationToken cancellationToken = default);
	Task<ProductResponse> GetByIdAsync(Guid productCode,
		CancellationToken cancellationToken = default);
	Task CreateAsync(string userId, ProductDto productForCreationDto,
		CancellationToken cancellationToken = default);
	Task UpdateAsync(string userId, Guid productId,
		ProductDto productForUpdateDto,
		CancellationToken cancellationToken = default);
	Task DeleteAsync(string userId, Guid productId, Guid? optionId, CancellationToken cancellationToken = default);
	Task<ProductDetailResponse> GetProductDetail(Guid productCode,
		CancellationToken cancellationToken = default);
	Task AdjustOptionQuantityAsync(string userId, Guid optionId, Guid productId, int count, CancellationToken cancellationToken = default);
	Task<ICollection<ManagementProductsResponse>> ManagementGetAllAsync(CancellationToken cancellationToken = default);
	Task<IList<string>> GetOptionImages(Guid optionId, CancellationToken cancellationToken);
	Task<ICollection<ProductsListResponse>> GetProductsList(CancellationToken cancellationToken = default);
	Task<ICollection<OptionsListResponse>> GetOptionsList(CancellationToken cancellationToken = default);
	
	/// <summary>
	/// Increase view count
	/// </summary>
	/// <param name="productId"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task ViewAsync(Guid productId, CancellationToken cancellationToken);
	
	/// <summary>
	/// Get recommended products
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<ICollection<ProductPreviewResponse>> GetRecommendedProducts(CancellationToken cancellationToken);

	/// <summary>
	/// Search products
	/// </summary>
	/// <param name="search"></param>
	/// <param name="filter"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<ICollection<ProductPreviewResponse>> SearchProductAsyncPreview(string search, FilteredSearchDto filter, CancellationToken cancellationToken);

	/// <summary>
	/// Retrieves related products
	/// </summary>
	/// <param name="categoryId"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<ICollection<ProductPreviewResponse>> GetRelatedProducts(int categoryId, CancellationToken cancellationToken);
}