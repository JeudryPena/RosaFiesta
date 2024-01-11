using Contracts.Model.Product.UserInteract;
using Contracts.Model.Product.UserInteract.Response;

namespace Services.Abstractions;

public interface IWishListService
{
	Task<WishListResponse> GetWishListAsync(string userId, CancellationToken cancellationToken = default);
	Task CreateWishListAsync(WishListDto wishList, string userId,
		CancellationToken cancellationToken = default);
	Task AddProductsToWishListAsync(string userId, List<ProductsWishListDto> wishListDto,
		CancellationToken cancellationToken = default);
	Task AddProductsToWishListAsync(string userId, Guid optionId, CancellationToken cancellationToken = default);
	Task DeleteProductFromWishListAsync(Guid wishListId, Guid optionId, CancellationToken cancellationToken = default);
	Task DeleteAllProductsFromWishListAsync(string userId, CancellationToken cancellationToken = default);
}