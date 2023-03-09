using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface ICategoryService
{
    Task<IEnumerable<CategoryResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CategoryResponse> CreateAsync(string? username, CategoryDto categoryDto, CancellationToken cancellationToken = default);
}