using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface IProductService
{
    Task<ICollection<ProductPreviewResponse>> GetAllAsyncPreview(CancellationToken cancellationToken = default);
    Task<ICollection<OptionPreviewResponse>> GetAllOptionsPreview(CancellationToken cancellationToken);
    Task<ProductsResponse> GetByIdAsync(string productId, CancellationToken cancellationToken = default);
    Task<ProductsResponse> CreateAsync(string? username, ProductDto productForCreationDto,
        CancellationToken cancellationToken = default);
    Task<ProductsResponse> UpdateAsync(string? username, string productId, ProductUpdateDto productForUpdateDto,
        CancellationToken cancellationToken = default);
    Task DeleteAsync(string productId, CancellationToken cancellationToken = default);
    Task<ProductAdjustResponse> AdjustProductQuantityAsync(string? username, string productId, int count, CancellationToken cancellationToken = default);
    Task<ProductDetailResponse> GetProductDetail(string productCode, CancellationToken cancellationToken = default);
    Task DeleteOptionAsync(string productId, int optionId, CancellationToken cancellationToken = default);
    Task DeleteOptionsAsync(string productId, CancellationToken cancellationToken = default);
    Task<OptionAdjustResponse> AdjustOptionQuantityAsync(string? username, int optionId, string productId, int count, CancellationToken cancellationToken = default);
    Task<OptionResponse> UpdateOptionAsync(string? username, int optionId, string productId,
        OptionUpdateDto optionForCreationDto, CancellationToken cancellationToken = default);
    Task<OptionResponse> CreateOptionAsync(string? username, string productId, OptionDto optionForCreationDto, CancellationToken cancellationToken);
    Task<ProductsResponse> GetOptionByIdAsync(string productId, int optionId, CancellationToken cancellationToken);
    Task<ProductDetailResponse> GetOptionDetailAsync(string productId, int optionId, CancellationToken cancellationToken = default);
}