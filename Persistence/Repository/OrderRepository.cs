using Domain.Entities.Product.Helpers;
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

	public async Task<IEnumerable<OrderEntity>> GetAllAsync(int? ordersToTake,
		CancellationToken cancellationToken = default)
	{
		IQueryable<OrderEntity> orders = _context.Orders.Include(x => x.Address).OrderByDescending(x => x.CreatedAt);
		if(ordersToTake != null)
			orders = orders.Take((int)ordersToTake);
		IEnumerable<OrderEntity> ordersList = await orders.ToListAsync(cancellationToken);
		return ordersList;
	}

	public async Task<OrderEntity> GetByIdAsync(Guid billId, CancellationToken cancellationToken = default)
	{
		OrderEntity? order = await _context.Orders.Include(x => x.Address).Include(x => x.Quote).Include(x => x.Details).ThenInclude(x => x.PurchaseOptions).Include(x => x.Details).ThenInclude(x => x.Warranty).FirstOrDefaultAsync(x => x.Id == billId, cancellationToken);
		if (order == null)
			throw new Exception("Order not found");
		return order;
	}

	public void CreateAsync(OrderEntity order) => _context.Orders.Add(order);

	public async Task<IEnumerable<OrderEntity>> GetByUserIdAsync(string userId, CancellationToken cancellationToken)
	=> await _context.Orders.Where(x => x.UserId == userId).OrderByDescending(x => x.CreatedAt).ToListAsync(cancellationToken);

	public void Update(OrderEntity order)
	=> _context.Orders.Update(order);

	public async Task<double> GetGainsAsync(CancellationToken cancellationToken)
	{
		double gains = await _context.Orders.Where(x => x.Status == OrderStatusType.Pagado || x.Status == OrderStatusType.Enviado || x.Status == OrderStatusType.Entregado).SumAsync(x => x.Total, cancellationToken);
		return gains;
	}
}