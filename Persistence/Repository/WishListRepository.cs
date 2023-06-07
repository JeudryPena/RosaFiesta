using Domain.Entities.Product.UserInteract;
using Domain.IRepository;

using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

internal sealed class WishListRepository : IWishListRepository
{
	private readonly RosaFiestaContext _rosaFiestaContext;

	public WishListRepository(RosaFiestaContext rosaFiestaContext)
	{
		_rosaFiestaContext = rosaFiestaContext;
	}

	public async Task<IEnumerable<WishListEntity>> GetWishListsAsync(string userId,
		CancellationToken cancellationToken = default)
	{
		List<WishListEntity> wishListEntities = await _rosaFiestaContext.WishesList
			.Where(wl => wl.UserId == userId)
			.ToListAsync(cancellationToken);
		return wishListEntities;
	}

	public async Task<WishListEntity> GetWishListByIdAsync(int wishListId, CancellationToken cancellationToken = default)
	{
		WishListEntity? wishListEntity = await _rosaFiestaContext.WishesList
			.Include(wl => wl.ProductsWish)
			.FirstOrDefaultAsync(wl => wl.Id == wishListId, cancellationToken);
		if (wishListEntity == null)
			throw new Exception("WishList not found");
		return wishListEntity;
	}

	public async Task<WishListEntity> GetWishWithProducts(int wishListId, CancellationToken cancellationToken = default)
	{
		WishListEntity? wishListEntity = await _rosaFiestaContext.WishesList.Include(wl => wl.ProductsWish).ThenInclude(pw => pw.Option)
			.FirstOrDefaultAsync(wl => wl.Id == wishListId, cancellationToken);
		if (wishListEntity == null)
			throw new Exception("WishList not found");
		return wishListEntity;
	}

	public async Task ExistingName(string wishListTitle, string userId)
	{
		bool exist = await _rosaFiestaContext.WishesList.AnyAsync(wl => wl.Title == wishListTitle && wl.UserId == userId);
		if (exist)
			throw new Exception("WishList with this name already exists");
	}

	public void Update(WishListEntity wishListEntity)
	=> _rosaFiestaContext.WishesList.Update(wishListEntity);

	public void Insert(WishListEntity wishListEntity)
	=> _rosaFiestaContext.WishesList.Add(wishListEntity);

	public void DeleteProduct(WishListProductsEntity wishListEntity)
	=> _rosaFiestaContext.WishesListProducts.Remove(wishListEntity);

	public void Delete(WishListEntity wishListEntity)
	=> _rosaFiestaContext.WishesList.Remove(wishListEntity);

	public async Task<WishListProductsEntity> GetWishListOption(int wishListId, int? optionId, CancellationToken cancellationToken)
	{
		WishListProductsEntity? wishListProductsEntity = await _rosaFiestaContext.WishesListProducts
			.FirstOrDefaultAsync(wl => wl.WishListId == wishListId && wl.OptionId == optionId, cancellationToken);
		if (wishListProductsEntity == null)
			throw new Exception("Option not found in this WishList");
		return wishListProductsEntity;
	}

	public void UpdateWishLists(IEnumerable<WishListEntity> wishListEntities)
	=> _rosaFiestaContext.WishesList.UpdateRange(wishListEntities);
}