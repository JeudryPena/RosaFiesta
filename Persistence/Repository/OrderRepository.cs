using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;
using Domain.IRepository;
using Microsoft.AspNetCore.Mvc.Formatters;
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
		double? gains = await _context.Orders.Where(x => (x.Status == OrderStatusType.Pagado || x.Status == OrderStatusType.Enviado || x.Status == OrderStatusType.Entregado || x.Status == OrderStatusType.Oficializado) && x.Total != null).SumAsync(x => x.Total, cancellationToken);
		return (double)gains;
	}

	public async Task<OrderComparativeData> GetOrderCompareAsync(DateOnly start, DateOnly end, CancellationToken cancellationToken)
	{
		OrderComparativeData orderComparativeData = new();
		orderComparativeData.Name = "Ordenes";
		orderComparativeData.Value = await _context.Orders.Where(x => DateOnly.FromDateTime(x.CreatedAt.Date) >= start && DateOnly.FromDateTime(x.CreatedAt.Date) <= end && (x.Status == OrderStatusType.Pagado || x.Status == OrderStatusType.Oficializado || x.Status == OrderStatusType.Entregado)).CountAsync(cancellationToken);
		return orderComparativeData;
	}

	public async Task<OrderComparativeData> GetQuotesCompareAsync(DateOnly start, DateOnly end, CancellationToken cancellationToken)
	{
		OrderComparativeData orderComparativeData = new();
		orderComparativeData.Name = "Cotizaciones";
		orderComparativeData.Value = await _context.Quotes.Where(x => DateOnly.FromDateTime(x.CreatedAt.Date) >= start && DateOnly.FromDateTime(x.CreatedAt.Date) <= end).CountAsync(cancellationToken);
		return orderComparativeData;
	}

	public async Task<OrderComparativeData> GetRefundsCompareAsync(DateOnly start, DateOnly end, CancellationToken cancellationToken)
	{
		OrderComparativeData orderComparativeData = new();
		orderComparativeData.Name = "Reembolsos";
		orderComparativeData.Value = await _context.Orders.Where(x => (x.Status == OrderStatusType.Rembolso || x.Status == OrderStatusType.Reembolsado || x.Status == OrderStatusType.Devuelto) && DateOnly.FromDateTime(x.CreatedAt.Date) >= start && DateOnly.FromDateTime(x.CreatedAt.Date) <= end).CountAsync(cancellationToken);
		return orderComparativeData;
	}

	public async Task<double> GetGainsWithDatesAsync(CancellationToken cancellationToken, DateOnly start, DateOnly end)
	{
		double? gains = await _context.Orders.Where(x => (x.Status == OrderStatusType.Pagado || x.Status == OrderStatusType.Enviado || x.Status == OrderStatusType.Entregado || x.Status == OrderStatusType.Oficializado && x.Total != null) && DateOnly.FromDateTime(x.CreatedAt.Date) >= start && DateOnly.FromDateTime(x.CreatedAt.Date) <= end).SumAsync(x => x.Total, cancellationToken) ?? 0;
		return (double)gains;
	}
}