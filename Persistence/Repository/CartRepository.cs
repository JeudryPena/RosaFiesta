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
            .Include(c => c.Details.Where(cd => cd.OrderSku == null)).Include(c => c.UserEntity).ToListAsync();

    public async Task<CartEntity> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        CartEntity? cart = await _context.Carts
            .Include(c => c.Details.Where(cd => cd.OrderSku == null)).Include(c => c.UserEntity)
            .FirstOrDefaultAsync(c => c.UserId == id, cancellationToken);
        if (cart == null )
            throw new Exception("Cart not found");
        return cart;
    }

    public void UpdateCartItem(PurchaseDetailEntity cartItem) =>
        _context.PurchaseDetails.Update(cartItem);

    public void DeleteDetails(ICollection<PurchaseDetailEntity> cartDetails) =>
    _context.PurchaseDetails.RemoveRange(cartDetails);

    public void UpdateCart(CartEntity cart)
    {
        _context.Carts.Update(cart);
    }

    public async Task<CartEntity> GetCartWithProductAndOption(string userId, CancellationToken cancellationToken)
    {
        CartEntity? cart = await _context.Carts
            .Include(c => c.Details.Where(cd => cd.OrderSku == null))
            .ThenInclude(cd => cd.Product)
            .Include(c => c.Details.Where(cd => cd.OrderSku == null))
            .ThenInclude(cd => cd.Option)
            .FirstOrDefaultAsync(c => c.UserId == userId, cancellationToken);
        if (cart == null)
            throw new Exception("Cart not found");
        return cart;
    }

    public async Task<ICollection<PurchaseDetailEntity>> GetCartDetails(string userId, CancellationToken cancellationToken = default)
    {
        CartEntity? cart = await _context.Carts
            .Include(c => c.Details.Where(cd => cd.OrderSku == null))
            .FirstOrDefaultAsync(c => c.UserId == userId, cancellationToken);
        if (cart == null)
            throw new Exception("Cart not found");
        if (cart.Details == null)
            throw new Exception("Cart is empty");
        return cart.Details;
    }
}