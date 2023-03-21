using Domain.Entities.Product.UserInteract;

namespace Domain.IRepository;

public interface IWishListRepository
{
    Task<IEnumerable<WishListEntity>> GetWishListsAsync(string userId, CancellationToken cancellationToken = default);
    Task<WishListEntity> GetWishListByIdAsync(int wishListId, CancellationToken cancellationToken = default);
    Task<WishListEntity> GetWishWithProducts(int wishListId, CancellationToken cancellationToken = default);
    Task<WishListProductsEntity> GetWishListProduct(int wishListId, string productId, CancellationToken cancellationToken = default);
    Task ExistingName(string wishListTitle, string userId);
    void Update(WishListEntity wishListEntity);
    void Insert(WishListEntity wishListEntity);
    void DeleteProduct(WishListProductsEntity wishListEntity);
    void Delete(WishListEntity wishListEntity);
}