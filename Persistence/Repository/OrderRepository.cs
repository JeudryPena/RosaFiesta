using Domain.Entities.Product.UserInteract;
using Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

internal sealed class OrderRepository: IOrderRepository
{
    private readonly RosaFiestaContext _context;
    
    public OrderRepository(RosaFiestaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderEntity>> GetAllAsync(CancellationToken cancellationToken = default) => await _context.Orders.ToListAsync(cancellationToken);

    public async Task<OrderEntity> GetByIdAsync(int billId, CancellationToken cancellationToken = default)
    {
        OrderEntity? order = await _context.Orders.FirstOrDefaultAsync(x => x.SKU == billId, cancellationToken);
        if (order == null)
        {
            throw new Exception("Order not found");
        }
        return order;
    }
    
    public void CreateAsync(OrderEntity order) => _context.Orders.Add(order);
    
    public void Update(OrderEntity order) => _context.Orders.Update(order);
    
    public void Delete(OrderEntity order) => _context.Orders.Remove(order);
}