using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface IProductService
{
	Task<ICollection<ProductPreviewResponse>> GetAllAsyncPreview(CancellationToken cancellationToken = default);
	Task<ProductResponse> GetByIdAsync(string productCode, int optionId,
		CancellationToken cancellationToken = default);
	Task<ProductResponse> CreateAsync(string userId, ProductDto productForCreationDto,
		CancellationToken cancellationToken = default);
	Task<ProductResponse> UpdateAsync(string userId, int optionId, string productId,
		ProductUpdateDto productForUpdateDto,
		CancellationToken cancellationToken = default);
	Task DeleteAsync(string userId, string productId, int? optionId, CancellationToken cancellationToken = default);
	Task<ProductDetailResponse> GetProductDetail(string code, int productCode,
		CancellationToken cancellationToken = default);
	Task<OptionAdjustResponse> AdjustOptionQuantityAsync(string userId, int optionId, string productId, int count, CancellationToken cancellationToken = default);
	Task<ICollection<ProductsResponse>> ManagementGetAllAsync(CancellationToken cancellationToken = default);
}