using Domain.Entities.Product.UserInteract;
using Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

internal sealed class CartRepository: ICartRepository
{
    private readonly RosaFiestaContext _context;
    
    public CartRepository(RosaFiestaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CartEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _context.Carts
            .Include(c => c.Products)
            .Include(c => c.UserEntity)
            .ToListAsync(cancellationToken);

    public async Task<CartEntity> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        CartEntity? cart = await _context.Carts
            .Include(c => c.Products)
            .Include(c => c.UserEntity)
            .FirstOrDefaultAsync(c => c.UserId == id, cancellationToken);
        if (cart == null)
        {
            throw new Exception("Cart not found");
        }
        return cart;
    }

    public void Insert(List<CartProductsEntity> cartProducts) => _context.CartsProducts.AddRange(cartProducts);
 
}