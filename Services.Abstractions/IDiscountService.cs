using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface IDiscountService
{
	Task<IEnumerable<ManagementDiscountsResponse>> ManagementGetAllAsync(CancellationToken cancellationToken = default);
	Task<DiscountResponse> GetDiscountAsync(string discountId, CancellationToken cancellationToken = default);
	Task CreateDiscountAsync(string userId, DiscountDto discount, CancellationToken cancellationToken = default);
	Task UpdateDiscountAsync(string userId, string discountId, DiscountDto discountDto,
		CancellationToken cancellationToken = default);
	Task DeleteDiscountAsync(string userId, string discountId, CancellationToken cancellationToken = default);
	Task<ManagementDiscountsResponse> GetManagementDiscountAsync(string code, CancellationToken cancellationToken = default);
}