using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;
using Domain.IRepository;
using Mapster;
using Services.Abstractions;

namespace Services;

internal sealed class WishListService: IWishListService
{
    private readonly IRepositoryManager _repositoryManager;
    
    public WishListService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    
    public async Task<WishListResponse> GetWishListAsync(int wishListId, CancellationToken cancellationToken = default)
    {
        WishListEntity wishListEntity = await _repositoryManager.WishListRepository.GetWishWithProducts(wishListId, cancellationToken);
        WishListResponse wishListResponse = wishListEntity.Adapt<WishListResponse>();
        if(wishListEntity.ProductsWish != null)
            wishListResponse.Products = wishListEntity.ProductsWish.Adapt<ICollection<ProductCartResponse>>();
        return wishListResponse;    
    }
    
    public async Task<IEnumerable<WishListPreviewResponse>> GetWishListsAsync(string userId, CancellationToken cancellationToken = default)
    {
        IEnumerable<WishListEntity> wishListEntities = await _repositoryManager.WishListRepository.GetWishListsAsync(userId, cancellationToken);
        IEnumerable<WishListPreviewResponse> wishListResponse = wishListEntities.Adapt<IEnumerable<WishListPreviewResponse>>();
        return wishListResponse;
    }

    public async Task<WishListResponse> CreateWishListAsync(WishListDto wishList, string userId,
        CancellationToken cancellationToken = default)
    {
        await _repositoryManager.WishListRepository.ExistingName(wishList.Title, userId);
        WishListEntity wishListEntity = new()
        {
            Title = wishList.Title,
            Description = wishList.Description,
            UserId = userId,
            CreatedDate = DateTimeOffset.Now,
        };
        if(wishList.ProductsId != null)
        {
            wishListEntity.ProductsWish = new List<WishListProductsEntity>();
            foreach (var i in wishList.ProductsId)
            {
                wishListEntity.ProductsWish.Add(new()
                {
                    WishListId = wishListEntity.Id,
                    ProductId = i,
                });
            }
        }
        
        _repositoryManager.WishListRepository.Insert(wishListEntity);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        WishListResponse wishListResponse = wishListEntity.Adapt<WishListResponse>();
        return wishListResponse;
    }

    public async Task<WishListProductsResponse> AddProductToWishListAsync(int wishListId, List<string> productsId, CancellationToken cancellationToken = default)
    {
        WishListEntity wishListEntity = await _repositoryManager.WishListRepository.GetWishListByIdAsync(wishListId, cancellationToken);
        if (wishListEntity.ProductsWish == null)
            wishListEntity.ProductsWish = new List<WishListProductsEntity>();
        foreach (var i in productsId)
        {
            wishListEntity.ProductsWish.Add(new()
            {
                WishListId = wishListEntity.Id,
                ProductId = i,
            });
        }
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        WishListProductsResponse wishListProductsResponse = wishListEntity.Adapt<WishListProductsResponse>();
        return wishListProductsResponse;
    }

    public async Task<WishListProductsResponse> DeleteProductFromWishListAsync(int wishListId, string productId, CancellationToken cancellationToken)
    {
        WishListProductsEntity wishListEntity = await _repositoryManager.WishListRepository.GetWishListProduct(wishListId, productId, cancellationToken);
        _repositoryManager.WishListRepository.DeleteProduct(wishListEntity);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        WishListProductsResponse wishListProductsResponse = wishListEntity.Adapt<WishListProductsResponse>();
        return wishListProductsResponse;
    }

    public async Task DeleteAllProductsFromWishListAsync(int wishListId, CancellationToken cancellationToken = default)
    {
        WishListEntity wishListEntity = await _repositoryManager.WishListRepository.GetWishListByIdAsync(wishListId, cancellationToken);
        if(wishListEntity.ProductsWish == null)
            throw new Exception("Wish list is alredy empty");
        wishListEntity.ProductsWish.Clear();
        _repositoryManager.WishListRepository.Update(wishListEntity);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteWishListAsync(int wishListId, CancellationToken cancellationToken = default)
    {
        WishListEntity wishListEntity = await _repositoryManager.WishListRepository.GetWishListByIdAsync(wishListId, cancellationToken);
        _repositoryManager.WishListRepository.Delete(wishListEntity);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<WishListResponse> UpdateWishListAsync(string userId, int wishListId, WishListDto wishList, CancellationToken cancellationToken)
    {
        WishListEntity wishListEntity = await _repositoryManager.WishListRepository.GetWishListByIdAsync(wishListId, cancellationToken);
        if (wishListEntity.UserId != userId)
            throw new Exception("You can't update this wish list");
        wishListEntity.Title = wishList.Title;
        wishListEntity.Description = wishList.Description;
        _repositoryManager.WishListRepository.Update(wishListEntity);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        WishListResponse wishListResponse = wishListEntity.Adapt<WishListResponse>();
        return wishListResponse;
    }

    public async Task DeleteAllWishListsAsync(string userId, CancellationToken cancellationToken)
    {
        IEnumerable<WishListEntity> wishListEntities = await _repositoryManager.WishListRepository.GetWishListsAsync(userId, cancellationToken);
        foreach (var i in wishListEntities)
        {
            _repositoryManager.WishListRepository.Delete(i);
        }
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}