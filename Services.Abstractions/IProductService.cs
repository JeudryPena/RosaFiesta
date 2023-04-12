using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface IProductService
{
    Task<ICollection<ProductAndOptionsPreviewResponse>> GetAllAsyncPreview(CancellationToken cancellationToken = default);
    Task<ProductAndOptionResponse> GetByIdAsync(string productCode, int optionId,
        CancellationToken cancellationToken = default);
    Task<ProductAndOptionResponse> CreateAsync(string? userId, ProductDto productForCreationDto,
        CancellationToken cancellationToken = default);
    Task<ProductAndOptionResponse> UpdateAsync(string userId, int optionId, string productId,
        ProductUpdateDto productForUpdateDto,
        CancellationToken cancellationToken = default);
    Task DeleteAsync(string userId, string productId, int? optionId, CancellationToken cancellationToken = default);
    Task<ProductAndOptionDetailResponse> GetProductDetail(string code, int productCode,
        CancellationToken cancellationToken = default);
    Task<OptionAdjustResponse> AdjustOptionQuantityAsync(string userId, int optionId, string productId, int count, CancellationToken cancellationToken = default);
    Task<ProductAndOptionResponse> CreateOptionAsync(string userId, string productId, OptionDto optionForCreationDto,
        CancellationToken cancellationToken = default);
}