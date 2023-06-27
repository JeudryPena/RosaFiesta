using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface IProductService
{
	Task<ICollection<ProductPreviewResponse>> GetAllAsyncPreview(CancellationToken cancellationToken = default);
	Task<ProductResponse> GetByIdAsync(Guid productCode, int optionId,
		CancellationToken cancellationToken = default);
	Task CreateAsync(string userId, ProductDto productForCreationDto,
		CancellationToken cancellationToken = default);
	Task UpdateAsync(string userId, int optionId, Guid productId,
		ProductUpdateDto productForUpdateDto,
		CancellationToken cancellationToken = default);
	Task DeleteAsync(string userId, Guid productId, int? optionId, CancellationToken cancellationToken = default);
	Task<ProductDetailResponse> GetProductDetail(Guid productCode, int optionId,
		CancellationToken cancellationToken = default);
	Task<OptionAdjustResponse> AdjustOptionQuantityAsync(string userId, int optionId, Guid productId, int count, CancellationToken cancellationToken = default);
	Task<ICollection<ProductsResponse>> ManagementGetAllAsync(CancellationToken cancellationToken = default);
	Task<IEnumerable<OptionsListResponse>> GetOptionsAsync(CancellationToken cancellationToken = default);
}