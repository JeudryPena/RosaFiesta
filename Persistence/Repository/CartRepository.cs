using Domain.Entities.Product.UserInteract;
using Domain.IRepository;

using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

internal sealed class CartRepository : ICartRepository
{
	private readonly RosaFiestaContext _context;

	public CartRepository(RosaFiestaContext context)
	{
		_context = context;
	}

	public async Task<CartEntity> GetByIdAsync(string id, CancellationToken cancellationToken = default)
	{
		CartEntity? cart = await _context.Carts
			.Include(c => c.Details).ThenInclude(cd => cd.PurchaseOptions).ThenInclude(po => po.Option).ThenInclude(o => o.Image)
			.FirstOrDefaultAsync(c => c.UserId == id, cancellationToken);
		if (cart == null)
			throw new Exception("Cart not found");
		return cart;
	}

	public void UpdateCartItem(PurchaseDetailEntity cartItem) =>
		_context.PurchaseDetails.Update(cartItem);

	public void UpdateCart(CartEntity cart)
	=> _context.Carts.Update(cart);

	public async Task<IList<PurchaseDetailEntity>> GetCartDetails(string userId, CancellationToken cancellationToken = default)
	{
		CartEntity? cart = await _context.Carts
			.Include(c => c.Details).ThenInclude(x => x.PurchaseOptions).FirstOrDefaultAsync(c => c.UserId == userId, cancellationToken);
		if (cart == null)
			throw new Exception("Cart not found");
		if (cart.Details == null || cart.Details.Count == 0)
			throw new Exception("Cart is empty");
		return cart.Details;
	}

	public void UpdateDetailOption(PurchaseDetailOptions optionDetail) =>
	_context.PurchaseDetailsOptions.Update(optionDetail);

	public async Task<int> GetCartDetailsCountAsync(string userId, CancellationToken cancellationToken = default)
	{
		int count = await _context.PurchaseDetails
			.Where(cd => cd.Cart.UserId == userId)
			.SumAsync(cd => cd.PurchaseOptions.Sum(po => po.Quantity), cancellationToken);
			return count;
	}

	public void RemoveDetailOption(PurchaseDetailOptions optionDetail)
	=> _context.PurchaseDetailsOptions.Remove(optionDetail);

	public void RemoveDetail(PurchaseDetailEntity purchase)
	=> _context.PurchaseDetails.Remove(purchase);
}