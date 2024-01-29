using System.Web;
using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract.Response;

using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;
using Domain.IRepository;

using Mapster;
using Messaging;
using Microsoft.AspNetCore.WebUtilities;
using Services.Abstractions;

namespace Services;

internal sealed class OrderService : IOrderService
{
	private readonly IRepositoryManager _repositoryManager;
	private readonly IEmailSender _emailSender;

	public OrderService(IRepositoryManager repositoryManager, IEmailSender emailSender)
	{
		_repositoryManager = repositoryManager;
		_emailSender = emailSender;
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
					throw new Exception($"No se puede comprar el producto {option.Title} porque no hay suficiente stock");
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
			throw new Exception("You can't return this order, user not found");
		if (order.Status == OrderStatusType.Rembolso)
		{
			order.Status = OrderStatusType.Pagado;
		}
		else
		{
			if (order.CreatedAt.AddDays(31) < DateTimeOffset.UtcNow)
				return false;
			order.Status = OrderStatusType.Rembolso;
			await ReturnOrderEmailAsync(userId, orderId, cancellationToken);
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

	public async Task<bool> OficializeReturnOrderDetailAsync(string userId, Guid orderId, CancellationToken cancellationToken)
	{
		OrderEntity order = await _repositoryManager.OrderRepository.GetByIdAsync(orderId, cancellationToken);
		order.Status = OrderStatusType.Reembolsado;
		await _repositoryManager.UnitOfWork.SaveChangesAsync(userId, cancellationToken);
		return true;
	}
	
	public async Task ReturnOrderEmailAsync(string userId, Guid orderId, CancellationToken cancellationToken)
	{
		string userName = await _repositoryManager.UserRepository.GetUserName(userId, cancellationToken);
		
		string codeEncoded = HttpUtility.UrlEncode(userId);
		string orderIdEncoded = HttpUtility.UrlEncode(orderId.ToString());
		var param = new Dictionary<string, string?>
		{
			{"userId", codeEncoded},
			{"orderId", orderIdEncoded}
		};
		
		var callback = QueryHelpers.AddQueryString("http://localhost:4200/admin/dashboard/orders", param);
		
		var htmlButton = $"<a href='{callback}' style='background-color: #4CAF50; border: none; color: white; padding: 15px 32px; text-align: center; text-decoration: none; display: inline-block; font-size: 16px;'>Ver solicitud</a>";
		List<string> emails = await _repositoryManager.UserRepository.GetAdminEmails(cancellationToken);

		var message = new EmailMessage(emails, "Solicitud de reembolso realizada", $"El Usuario {userName} ha solicitado un reembolso, haz Click en el siguiente botón para ver detalles: <br/> <br/> {htmlButton}", null);
		await _emailSender.SendEmailAsync(message);
	}
	
	
}