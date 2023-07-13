using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract.Response;

using Domain.Entities.Product;
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

	public async Task<IEnumerable<OrderPreviewResponse>> GetAllAsync(CancellationToken cancellationToken = default)
	{
		IEnumerable<OrderEntity> orders = await _repositoryManager.OrderRepository.GetAllAsync(cancellationToken);
		IEnumerable<OrderPreviewResponse> orderResponse = orders.Adapt<IEnumerable<OrderPreviewResponse>>();
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

	public async Task<OrderResponse> OrderPurchaseAsync(string userId, Guid payMethodId,
		Guid addressId, CancellationToken cancellationToken = default)
	{
		PayMethodEntity payMethod = await _repositoryManager.PayMethodRepository.GetByIdAsync(payMethodId, cancellationToken);
		OrderEntity order = new();
		order.AddressId = addressId;
		order.PayMethodId = payMethod.Id;
		order.UserId = userId;
		order.Details = await _repositoryManager.CartRepository.GetCartDetails(userId, cancellationToken);
		foreach (PurchaseDetailEntity detail in order.Details)
		{
			foreach (var optionPurchase in detail.PurchaseOptions)
			{
				var option = await _repositoryManager.ProductRepository.GetOptionByIdAsync(optionPurchase.OptionId, cancellationToken);
				if (option.QuantityAvailable < optionPurchase.Quantity)
					throw new Exception("You can't add more than the quantity available");
				option.QuantityAvailable -= optionPurchase.Quantity;
				_repositoryManager.ProductRepository.UpdateOption(option);

				DiscountEntity? discount = await _repositoryManager.DiscountRepository.GetOptionDiscountAsync(option.Id, cancellationToken);
				if (discount != null)
				{
					double Value = optionPurchase.UnitPrice * discount.Value / 100;
					optionPurchase.UnitPrice -= Value;
				}
			}
			detail.OrderId = order.Id;
			detail.CartId = null;
		}
		_repositoryManager.OrderRepository.CreateAsync(order);
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
		OrderResponse orderResponse = order.Adapt<OrderResponse>();
		return orderResponse;
	}

	public async Task ReturnOrderDetailAsync(string userId, Guid purchaseNumber, Guid orderId, CancellationToken cancellationToken)
	{
		OrderEntity order = await _repositoryManager.OrderRepository.GetByIdAsync(orderId, cancellationToken);
		if (order.UserId != userId)
			throw new Exception("You can't return this order");
		if (order.CreatedAt.AddDays(31) < DateTimeOffset.UtcNow)
			throw new Exception("You can't return this order, the time limit has expired");
		if (order.Details == null)
			throw new Exception("You can't return this order, the detail doesn't exist");
		var detail = order.Details.FirstOrDefault(x => x.DetailId == purchaseNumber);
		if (detail == null)
			throw new Exception("You can't return this order, the detail doesn't exist");
		foreach (var optionPurchase in detail.PurchaseOptions)
		{
			var option = await _repositoryManager.ProductRepository.GetOptionByIdAsync(optionPurchase.OptionId, cancellationToken);
			option.QuantityAvailable += optionPurchase.Quantity;
			optionPurchase.IsReturned = true;
			_repositoryManager.ProductRepository.UpdateOption(option);
			_repositoryManager.PurchaseDetailRepository.UpdateOptionDetail(optionPurchase);
		}
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
	}
}