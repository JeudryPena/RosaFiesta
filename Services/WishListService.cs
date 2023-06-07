using Contracts.Model.Product.UserInteract;
using Contracts.Model.Product.UserInteract.Response;

using Domain.Entities.Product.UserInteract;
using Domain.IRepository;

using Mapster;

using Services.Abstractions;

namespace Services;

internal sealed class WishListService : IWishListService
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
			UserId = userId
		};
		if (wishList.OptionsId != null)
		{
			wishListEntity.ProductsWish = new List<WishListProductsEntity>();
			foreach (var i in wishList.OptionsId)
			{
				wishListEntity.ProductsWish.Add(new()
				{
					WishListId = wishListEntity.Id,
					OptionId = i,
				});
			}
		}
		_repositoryManager.WishListRepository.Insert(wishListEntity);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
		WishListResponse wishListResponse = wishListEntity.Adapt<WishListResponse>();
		return wishListResponse;
	}

	public async Task<WishListProductsResponse> AddProductToWishListAsync(int wishListId,
		List<ProductsWishListDto> wishListDto, CancellationToken cancellationToken = default)
	{
		WishListEntity wishListEntity = await _repositoryManager.WishListRepository.GetWishListByIdAsync(wishListId, cancellationToken);
		if (wishListEntity.ProductsWish == null)
			wishListEntity.ProductsWish = new List<WishListProductsEntity>();
		foreach (var i in wishListDto)
		{
			if (wishListEntity.ProductsWish.Any(x => x.OptionId == i.OptionId))
				throw new Exception("Product already exists in wish list");
			wishListEntity.ProductsWish.Add(new()
			{
				WishListId = wishListId,
				OptionId = i.OptionId,
			});
		}
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
		WishListProductsResponse wishListProductsResponse = wishListEntity.Adapt<WishListProductsResponse>();
		return wishListProductsResponse;
	}

	public async Task<WishListProductsResponse> DeleteProductFromWishListAsync(int wishListId, int optionId, CancellationToken cancellationToken)
	{
		WishListProductsEntity wishListEntity = await _repositoryManager.WishListRepository.GetWishListOption(wishListId, optionId, cancellationToken);
		_repositoryManager.WishListRepository.DeleteProduct(wishListEntity);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
		WishListProductsResponse wishListProductsResponse = wishListEntity.Adapt<WishListProductsResponse>();
		return wishListProductsResponse;
	}

	public async Task DeleteAllProductsFromWishListAsync(int wishListId, CancellationToken cancellationToken = default)
	{
		WishListEntity wishListEntity = await _repositoryManager.WishListRepository.GetWishListByIdAsync(wishListId, cancellationToken);
		if (wishListEntity.ProductsWish == null)
			throw new Exception("Wish list is alredy empty");
		wishListEntity.ProductsWish.Clear();
		_repositoryManager.WishListRepository.Update(wishListEntity);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
	}

	public async Task DeleteWishListAsync(int wishListId, CancellationToken cancellationToken = default)
	{
		WishListEntity wishListEntity = await _repositoryManager.WishListRepository.GetWishListByIdAsync(wishListId, cancellationToken);
		wishListEntity.IsDeleted = true;
		_repositoryManager.WishListRepository.Update(wishListEntity);
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
		foreach (WishListEntity i in wishListEntities)
		{
			i.IsDeleted = true;
		}
		_repositoryManager.WishListRepository.UpdateWishLists(wishListEntities);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
	}
}