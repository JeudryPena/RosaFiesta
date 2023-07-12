using Domain.Entities.Product.UserInteract;

namespace Domain.IRepository;

public interface IWishListRepository
{
    Task<IEnumerable<WishListEntity>> GetWishListsAsync(string userId, CancellationToken cancellationToken = default);
    Task<WishListEntity> GetWishListByIdAsync(string userId, CancellationToken cancellationToken = default);
    Task<WishListEntity> GetWishWithProducts(string userId, CancellationToken cancellationToken = default);
    void Update(WishListEntity wishListEntity);
    void Insert(WishListEntity wishListEntity);
    void DeleteProduct(WishListProductsEntity wishListEntity);
    Task<WishListProductsEntity> GetWishListOption(Guid wishlistId, Guid? optionId, CancellationToken cancellationToken);
}