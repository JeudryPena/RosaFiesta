using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface IDiscountService
{
    Task<IEnumerable<DiscountResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<DiscountResponse> GetDiscountAsync(string discountId, CancellationToken cancellationToken = default);
    Task<DiscountResponse> CreateDiscountAsync(string? userId, DiscountDto discount, CancellationToken cancellationToken = default);
    Task<DiscountResponse> UpdateDiscountAsync(string? userId, string discountId, DiscountDto discountDto,
        CancellationToken cancellationToken = default);
    Task DeleteDiscountAsync(string discountId, CancellationToken cancellationToken = default);
}