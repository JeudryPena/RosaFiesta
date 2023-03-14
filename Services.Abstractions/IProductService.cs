using Contracts.Model;
using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface IProductService
{
    Task<ProductsResponse> CreateAsync(string? username, ProductDto productForCreationDto,
        CancellationToken cancellationToken = default);
    Task<IEnumerable<ProductsResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ProductsResponse> GetByIdAsync(string productId, CancellationToken cancellationToken = default);
    Task<ProductsResponse> UpdateAsync(string? username, string productId, ProductUpdateDto productForUpdateDto,
        CancellationToken cancellationToken = default);
    Task DeleteAsync(string productId, CancellationToken cancellationToken = default);
    Task<ProductAdjustResponse> AdjustProductQuantityAsync(string? username, string productId, int count, CancellationToken cancellationToken = default);
}