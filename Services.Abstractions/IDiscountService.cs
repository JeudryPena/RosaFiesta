using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface IDiscountService
{
	Task<IEnumerable<ManagementDiscountsResponse>> ManagementGetAllAsync(CancellationToken cancellationToken = default);
	Task<DiscountResponse> GetDiscountAsync(Guid discountId, CancellationToken cancellationToken = default);
	Task CreateDiscountAsync(string userId, DiscountDto discount, CancellationToken cancellationToken = default);
	Task UpdateDiscountAsync(string userId, Guid discountId, DiscountDto discountDto,
		CancellationToken cancellationToken = default);
	Task DeleteDiscountAsync(string userId, Guid discountId, CancellationToken cancellationToken = default);
	Task<ManagementDiscountsResponse> GetManagementDiscountAsync(Guid discountId, CancellationToken cancellationToken = default);
	Task DeleteDiscountProductsAsync(string userId, Guid discountId, int? optionId, CancellationToken cancellationToken = default);
}