using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface IDiscountService
{
    Task<IEnumerable<DiscountResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<DiscountResponse> GetDiscountAsync(Guid discountId, CancellationToken cancellationToken = default);
    Task<DiscountResponse> CreateDiscountAsync(string? username, DiscountDto discount, CancellationToken cancellationToken = default);
    Task<DiscountResponse> UpdateDiscountAsync(string? username, Guid discountId, DiscountDto discountDto, CancellationToken cancellationToken = default);
    Task DeleteDiscountAsync(Guid discountId, CancellationToken cancellationToken = default);
}