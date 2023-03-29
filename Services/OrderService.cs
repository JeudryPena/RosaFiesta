using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract;
using Contracts.Model.Product.UserInteract.Response;
using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;
using Domain.IRepository;

using Mapster;

using Services.Abstractions;

namespace Services;

internal sealed class OrderService : IOrderService {
    private readonly IRepositoryManager _repositoryManager;

    public OrderService(IRepositoryManager repositoryManager) {
        _repositoryManager = repositoryManager;
    }

    public async Task<IEnumerable<OrderResponse>> GetAllAsync(CancellationToken cancellationToken = default) {
        IEnumerable<OrderEntity> orders = await _repositoryManager.OrderRepository.GetAllAsync(cancellationToken);
        IEnumerable<OrderResponse> orderResponse = orders.Adapt<IEnumerable<OrderResponse>>();
        return orderResponse;
    }

    public async Task<OrderResponse> GetByIdAsync(int billId, CancellationToken cancellationToken = default) {
        OrderEntity order = await _repositoryManager.OrderRepository.GetByIdAsync(billId, cancellationToken);
        OrderResponse orderResponse = order.Adapt<OrderResponse>();
        return orderResponse;
    }

    public async Task<OrderResponse> UpdateAsync(int billId, OrderDto orderDto,
        CancellationToken cancellationToken = default) {
        OrderEntity order = await _repositoryManager.OrderRepository.GetByIdAsync(billId, cancellationToken);
        order = orderDto.Adapt(order);
        _repositoryManager.OrderRepository.Update(order);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        OrderResponse orderResponse = order.Adapt<OrderResponse>();
        return orderResponse;
    }

    public async Task DeleteAsync(int billId, CancellationToken cancellationToken = default) {
        OrderEntity order = await _repositoryManager.OrderRepository.GetByIdAsync(billId, cancellationToken);
        _repositoryManager.OrderRepository.Delete(order);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<OrderResponse> OrderPurchaseAsync(string userId, Guid payMethodId, 
        OrderDto orderDto,
        CancellationToken cancellationToken = default)
    {
        PayMethodEntity payMethod = await _repositoryManager.PayMethodRepository.GetByIdAsync(payMethodId, cancellationToken);
        OrderEntity order = orderDto.Adapt<OrderEntity>();
        order.OrderDate = DateTimeOffset.UtcNow;
        order.PayMethodId = payMethod.Id;
        order.UserId = userId;
        order.Details = await _repositoryManager.CartRepository.GetCartDetails(userId, cancellationToken);
        foreach (PurchaseDetailEntity detail in order.Details)
        {
            if (detail.Option != null)
            {
                if (detail.Option.QuantityAvaliable < detail.Quantity)
                    throw new Exception("You can't add more than the quantity available");
                detail.Option.QuantityAvaliable -= detail.Quantity;
            }
            else {
                if (detail.Product.QuantityAvaliable < detail.Quantity)
                    throw new Exception("You can't add more than the quantity available");
                detail.Product.QuantityAvaliable -= detail.Quantity;
            }
            if (detail.AppliedId != null)
            {
                DiscountEntity discount =
                    await _repositoryManager.DiscountRepository.GetByAppliedId(detail.AppliedId, cancellationToken);
                if(discount.AppliedDiscounts != null && discount.AppliedDiscounts.Count(x => x.UserId == userId) >= discount.MaxTimesApply)
                    if (discount.DiscountType == DiscountType.Percentage)
                        detail.UnitPrice -= detail.UnitPrice * discount.DiscountValue / 100;
                    else
                        detail.UnitPrice -= discount.DiscountValue;
            }
            detail.OrderSku = order.SKU;
            detail.CartId = null;
        }
        _repositoryManager.OrderRepository.CreateAsync(order);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        OrderResponse orderResponse = order.Adapt<OrderResponse>();
        return orderResponse;
    }

    public async Task RemoveDiscountAsync(int purchaseNumber, CancellationToken cancellationToken = default)
    {
        AppliedDiscountEntity appliedDiscount = await _repositoryManager.DiscountRepository.GetAppliedDiscount(purchaseNumber, cancellationToken);
        _repositoryManager.DiscountRepository.DeleteAppliedDiscount(appliedDiscount);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<ValidDiscountResponse> SelectDiscountAsync(string userId, int purchaseNumber, string discountCode,
        CancellationToken cancellationToken = default)
    {
        PurchaseDetailEntity detail = await _repositoryManager.PurchaseDetailRepository.GetByIdAsync(purchaseNumber, cancellationToken);
        if (detail.DiscountApplied == null)
            detail.DiscountApplied = new AppliedDiscountEntity { UserId = userId };
        detail.DiscountApplied.DiscountCode = discountCode;
        detail.DiscountApplied.AppliedDate = DateTimeOffset.UtcNow;
        _repositoryManager.PurchaseDetailRepository.Update(detail);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        ValidDiscountResponse validDiscountResponse = detail.DiscountApplied.Adapt<ValidDiscountResponse>();
        return validDiscountResponse;
    }

    public async Task<IEnumerable<OrderResponse>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default) 
    {
        IEnumerable<OrderEntity> orders = await _repositoryManager.OrderRepository.GetByUserIdAsync(userId, cancellationToken);
        IEnumerable<OrderResponse> orderResponse = orders.Adapt<IEnumerable<OrderResponse>>();
        return orderResponse;
    }
}