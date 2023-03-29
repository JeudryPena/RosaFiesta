using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract;
using Contracts.Model.Product.UserInteract.Response;

namespace Services.Abstractions;

public interface IWishListService
{
    Task<IEnumerable<WishListPreviewResponse>> GetWishListsAsync(string userId, CancellationToken cancellationToken = default);
    Task<WishListResponse> GetWishListAsync(int wishListId, CancellationToken cancellationToken = default);
    Task<WishListResponse> CreateWishListAsync(WishListDto wishList, string userId,
        CancellationToken cancellationToken = default);
    Task<WishListProductsResponse> AddProductToWishListAsync(int wishListId, List<ProductsWishListDto> wishListDto,
        CancellationToken cancellationToken = default);
    Task<WishListProductsResponse> DeleteProductFromWishListAsync(int wishListId, string productId, CancellationToken cancellationToken = default);
    Task DeleteAllProductsFromWishListAsync(int wishListId, CancellationToken cancellationToken = default);
    Task DeleteWishListAsync(int wishListId, CancellationToken cancellationToken = default);
    Task<WishListResponse> UpdateWishListAsync(string userId, int wishListId, WishListDto wishList, CancellationToken cancellationToken);
    Task DeleteAllWishListsAsync(string userId, CancellationToken cancellationToken);
}