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

    public async Task<IEnumerable<CartEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _context.Carts
            .Include(c => c.Details.Where(cd => cd.OrderSku == null)).ThenInclude(x => x.PurchaseOptions).ToListAsync();

    public async Task<CartEntity> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        CartEntity? cart = await _context.Carts
            .Include(c => c.Details.Where(cd => cd.OrderSku == null)).ThenInclude(cd => cd.PurchaseOptions)
            .FirstOrDefaultAsync(c => c.UserId == id, cancellationToken);
        if (cart == null )
            throw new Exception("Cart not found");
        return cart;
    }

    public void UpdateCartItem(PurchaseDetailEntity cartItem) =>
        _context.PurchaseDetails.Update(cartItem);
    
    public void UpdateCart(CartEntity cart)
    => _context.Carts.Update(cart);

    public async Task<ICollection<PurchaseDetailEntity>> GetCartDetails(string userId, CancellationToken cancellationToken = default)
    {
        CartEntity? cart = await _context.Carts
            .Include(c => (c.Details ?? new List<PurchaseDetailEntity>()).Where(cd => cd.OrderSku == null)).FirstOrDefaultAsync(c => c.UserId == userId, cancellationToken);
        if (cart == null)
            throw new Exception("Cart not found");
        if (cart.Details == null || cart.Details.Count == 0)
            throw new Exception("Cart is empty");
        return cart.Details;
    }

    public void UpdateDetailOption(PurchaseDetailOptions optionDetail) =>
    _context.PurchaseDetailsOptions.Update(optionDetail);
}