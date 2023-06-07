using Domain.Entities.Product.UserInteract;
using Domain.IRepository;

using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

internal sealed class OrderRepository : IOrderRepository
{
	private readonly RosaFiestaContext _context;

	public OrderRepository(RosaFiestaContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<OrderEntity>> GetAllAsync(CancellationToken cancellationToken = default) => await _context.Orders.Where(x => x.IsDeleted == false).ToListAsync(cancellationToken);

	public async Task<OrderEntity> GetByIdAsync(int billId, CancellationToken cancellationToken = default)
	{
		OrderEntity? order = await _context.Orders.Include(x => x.Details).Include(x => x.Address).FirstOrDefaultAsync(x => x.SKU == billId, cancellationToken);
		if (order == null)
			throw new Exception("Order not found");
		if (order.IsDeleted)
			throw new Exception("Order is deleted");
		return order;
	}

	public void CreateAsync(OrderEntity order) => _context.Orders.Add(order);

	public async Task<IEnumerable<OrderEntity>> GetByUserIdAsync(string userId, CancellationToken cancellationToken)
	=> await _context.Orders.Where(x => x.UserId == userId && x.IsDeleted == false).ToListAsync(cancellationToken);

	public void Update(OrderEntity order)
	=> _context.Orders.Update(order);
}