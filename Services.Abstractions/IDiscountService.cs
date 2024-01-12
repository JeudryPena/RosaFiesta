using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface IDiscountService
{
	Task<IEnumerable<ManagementDiscountsResponse>> ManagementGetAllAsync(CancellationToken cancellationToken = default);
	Task<DiscountResponse?> GetOptionDiscount(Guid optionId, CancellationToken cancellationToken = default);
	Task CreateDiscountAsync(string userId, DiscountDto discount, CancellationToken cancellationToken = default);
	Task UpdateDiscountAsync(string userId, Guid discountId, DiscountDto discountDto,
		CancellationToken cancellationToken = default);
	Task DeleteDiscountAsync(string userId, Guid discountId, CancellationToken cancellationToken = default);
	Task<ManagementDiscountsResponse> GetManagementDiscountAsync(Guid discountId, CancellationToken cancellationToken = default);
	Task DeleteDiscountProductsAsync(string userId, Guid discountId, Guid? optionId, CancellationToken cancellationToken = default);
	
	/// <summary>
	/// Get all discounted products with highest discount
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<DiscountResponse> GetHotOffersAsync(CancellationToken cancellationToken);
}