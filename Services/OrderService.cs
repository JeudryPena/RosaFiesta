using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract.Response;

using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;
using Domain.IRepository;

using Mapster;

using Services.Abstractions;

namespace Services;

internal sealed class OrderService : IOrderService
{
	private readonly IRepositoryManager _repositoryManager;

	public OrderService(IRepositoryManager repositoryManager)
	{
		_repositoryManager = repositoryManager;
	}

	public async Task<IEnumerable<OrderManagementPreviewResponse>> GetAllAsync(int? ordersToTake,
		CancellationToken cancellationToken = default)
	{
		IEnumerable<OrderEntity> orders = await _repositoryManager.OrderRepository.GetAllAsync(ordersToTake, cancellationToken);
		IEnumerable<OrderManagementPreviewResponse> orderResponse = orders.Adapt<IEnumerable<OrderManagementPreviewResponse>>();
		return orderResponse;
	}

	public async Task<IEnumerable<OrderPreviewResponse>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default)
	{
		IEnumerable<OrderEntity> orders = await _repositoryManager.OrderRepository.GetByUserIdAsync(userId, cancellationToken);
		IEnumerable<OrderPreviewResponse> orderResponse = orders.Adapt<IEnumerable<OrderPreviewResponse>>();
		return orderResponse;
	}

	public async Task<OrderResponse> GetByIdAsync(Guid orderId, CancellationToken cancellationToken = default)
	{
		OrderEntity order = await _repositoryManager.OrderRepository.GetByIdAsync(orderId, cancellationToken);
		OrderResponse orderResponse = order.Adapt<OrderResponse>();
		return orderResponse;
	}

	public async Task<OrderResponse> OrderPurchaseAsync(OrderDto orderDto, string userId,
		CancellationToken cancellationToken = default)
	{
		OrderEntity order = new();
		order = orderDto.Adapt<OrderEntity>();
		order.UserId = userId;
		order.Details = new List<PurchaseDetailEntity>();
		
		IList<PurchaseDetailEntity> details = await _repositoryManager.CartRepository.GetCartDetails(userId, cancellationToken);
		foreach (PurchaseDetailEntity detail in details.ToList())
		{
			foreach (var optionPurchase in detail.PurchaseOptions.ToList())
			{
				var option = await _repositoryManager.ProductRepository.GetOptionByIdAsync(optionPurchase.OptionId, cancellationToken);
				if (option.QuantityAvailable < optionPurchase.Quantity)
					throw new Exception("You can't add more than the quantity available");
				option.QuantityAvailable -= optionPurchase.Quantity;
				_repositoryManager.ProductRepository.UpdateOption(option);
				optionPurchase.Title = option.Title;
				DiscountEntity? discount = await _repositoryManager.DiscountRepository.GetOptionDiscountAsync(option.Id, cancellationToken);
				optionPurchase.UnitPrice = option.Price;
				if (discount != null)
				{
					double value = option.Price * discount.Value / 100;
					optionPurchase.UnitPrice -= value;
					optionPurchase.Discounted = value;
				}
				optionPurchase.IsService = await _repositoryManager.ProductRepository.IsService(option.ProductId, cancellationToken);
				detail.PurchaseOptions.Add(optionPurchase);
			}
			detail.CartId = null;
			detail.Cart = null;
			order.Details.Add(detail);
		}
		order.Status = OrderStatusType.Pagado;
		_repositoryManager.OrderRepository.CreateAsync(order);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
		OrderResponse orderResponse = order.Adapt<OrderResponse>();
		return orderResponse;
	}

	public async Task<bool> ReturnOrderDetailAsync(string userId, Guid orderId,
		CancellationToken cancellationToken)
	{
		OrderEntity order = await _repositoryManager.OrderRepository.GetByIdAsync(orderId, cancellationToken);
		if (order.UserId != userId)
			throw new Exception("You can't return this order");
		if(order.Status == OrderStatusType.Rembolso)
			order.Status = OrderStatusType.Pagado;
		else
		{
			if (order.CreatedAt.AddDays(31) < DateTimeOffset.UtcNow)
				return false;
			order.Status = OrderStatusType.Rembolso;
		}
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
		return true;
	}

	public async Task<OrderResponse> CreateOrderAsync(OrderDto orderDto, string userId,
		CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public async Task<double> GetGainsAsync(CancellationToken cancellationToken)
	{
		 double gains = await _repositoryManager.OrderRepository.GetGainsAsync(cancellationToken);
		 return gains;
	}
}