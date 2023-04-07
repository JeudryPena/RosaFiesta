using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract;
using Contracts.Model.Product.UserInteract.Response;
using Contracts.Model.Security;
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

    public async Task<IEnumerable<OrderPreviewResponse>> GetAllAsync(CancellationToken cancellationToken = default) {
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

    public async Task<OrderResponse> GetByIdAsync(int billId, CancellationToken cancellationToken = default) {
        OrderEntity order = await _repositoryManager.OrderRepository.GetByIdAsync(billId, cancellationToken);
        OrderResponse orderResponse = order.Adapt<OrderResponse>();
        return orderResponse;
    }

    public async Task<OrderResponse> OrderPurchaseAsync(string userId, Guid payMethodId,
        Guid addressId, CancellationToken cancellationToken = default)
    {
        PayMethodEntity payMethod = await _repositoryManager.PayMethodRepository.GetByIdAsync(payMethodId, cancellationToken);
        OrderEntity order = new();
        order.AddressId = addressId;
        order.OrderDate = DateTimeOffset.UtcNow;
        order.PayMethodId = payMethod.Id;
        order.UserId = userId;
        order.Details = await _repositoryManager.CartRepository.GetCartDetails(userId, cancellationToken);
        foreach (PurchaseDetailEntity detail in order.Details)
        {
            foreach (var optionPurchase in detail.PurchaseOptions)
            {
                var option = await _repositoryManager.ProductRepository.GetOptionByIdAsync(optionPurchase.OptionId, cancellationToken);
                if (option.QuantityAvaliable < optionPurchase.Quantity)
                    throw new Exception("You can't add more than the quantity available");
                option.QuantityAvaliable -= optionPurchase.Quantity;
                _repositoryManager.ProductRepository.UpdateOption(option);

                var discount = await _repositoryManager.DiscountRepository.GetByAppliedId(optionPurchase.AppliedId, cancellationToken);
                if (discount.AppliedDiscounts?.Count(x => x.UserId == userId) >= discount.MaxTimesApply)
                {
                    double discountValue = discount.DiscountType == DiscountType.Percentage
                        ? optionPurchase.UnitPrice * discount.DiscountValue / 100
                        : discount.DiscountValue;
                    optionPurchase.UnitPrice -= discountValue;
                }
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

    public async Task<ValidDiscountResponse> SelectDiscountAsync(string userId, int purchaseNumber, string discountCode, int optionId, CancellationToken cancellationToken = default)
    {
        PurchaseDetailOptions detail = await _repositoryManager.PurchaseDetailRepository.GetDetailOptionByIdAsync(optionId, purchaseNumber, cancellationToken);
        if (detail.DiscountApplied == null)
            detail.DiscountApplied = new AppliedDiscountEntity { UserId = userId };
        detail.DiscountApplied.DiscountCode = discountCode;
        detail.DiscountApplied.AppliedDate = DateTimeOffset.UtcNow;
        _repositoryManager.PurchaseDetailRepository.UpdateOptionDetail(detail);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        ValidDiscountResponse validDiscountResponse = detail.DiscountApplied.Adapt<ValidDiscountResponse>();
        return validDiscountResponse;
    }
}