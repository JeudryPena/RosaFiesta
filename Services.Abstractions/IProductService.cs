using Contracts.Model;
using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface IProductService
{
    Task<ProductsResponse> CreateAsync(string? username, ProductEntityDto productForCreationDto,
        CancellationToken cancellationToken = default);
    Task<IEnumerable<ProductsResponse>> GetAllAsync(CancellationToken cancellationToken = default);
}