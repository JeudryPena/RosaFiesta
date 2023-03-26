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
        if (payMethod == null) throw new Exception("Pay method not found");
        OrderEntity order = orderDto.Adapt<OrderEntity>();
        order.OrderDate = DateTimeOffset.UtcNow;
        order.PayMethodId = payMethod.Id;
        order.UserId = userId;
        CartEntity cart = await _repositoryManager.CartRepository.GetByIdAsync(userId, cancellationToken);
        List<ProductEntity> products = new();
        if (cart.Details == null)
            throw new Exception("Cart is empty");
        _repositoryManager.OrderRepository.CreateAsync(order);
        order.Details = cart.Details;
        foreach (PurchaseDetailEntity detail in order.Details)
        {
            if (detail.ProductId == null) throw new Exception("Product not found");
            ProductEntity product =
                await _repositoryManager.ProductRepository.GetByIdAsync(detail.ProductId, cancellationToken);
            if (product.QuantityAvaliable < detail.Quantity)
                throw new Exception("You can't add more than the quantity available");
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
            product.QuantityAvaliable -= detail.Quantity;
            products.Add(product);
        }
        _repositoryManager.PurchaseDetailRepository.UpdateRange(order.Details);
        _repositoryManager.ProductRepository.UpdateRange(products);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        OrderResponse orderResponse = order.Adapt<OrderResponse>();
        return orderResponse;
    }

    public async Task<ValidDiscountResponse> ApplyDiscountAsync(int purchaseNumber, string userId, string discountCode, CancellationToken cancellationToken)
    {
        PurchaseDetailEntity detail = await _repositoryManager.PurchaseDetailRepository.GetByIdAsync(purchaseNumber, cancellationToken);
        if (detail.ProductId == null) throw new Exception("Product not found");
        DiscountEntity discount =
            await _repositoryManager.DiscountRepository.GetValidDiscountAsync(discountCode, detail.ProductId,
                cancellationToken);
        if(discount.AppliedDiscounts != null && discount.AppliedDiscounts.Count(x => x.UserId == userId) * detail.Quantity >= discount.MaxTimesApply)
            throw new Exception("You have already exhausted the maximum use of this discount");
        AppliedDiscountEntity appliedDiscount = new AppliedDiscountEntity
        {
            DiscountCode = discountCode,
            UserId = userId,
            PurchaseNumber = purchaseNumber,
            AppliedDate = DateTimeOffset.UtcNow
        };
        _repositoryManager.DiscountRepository.CreateAppliedDiscount(appliedDiscount);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        ValidDiscountResponse validDiscountResponse = discount.Adapt<ValidDiscountResponse>();
        return validDiscountResponse;
    }

    public async Task RemoveDiscountAsync(int purchaseNumber, CancellationToken cancellationToken = default)
    {
        AppliedDiscountEntity appliedDiscount = await _repositoryManager.DiscountRepository.GetAppliedDiscount(purchaseNumber, cancellationToken);
        _repositoryManager.DiscountRepository.DeleteAppliedDiscount(appliedDiscount);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<ValidDiscountResponse> UpdateDiscountAsync(string userId, int purchaseNumber, string discountCode,
        CancellationToken cancellationToken)
    {
        PurchaseDetailEntity detail = await _repositoryManager.PurchaseDetailRepository.GetByIdAsync(purchaseNumber, cancellationToken);
        if (detail.ProductId == null) throw new Exception("Product not found");
        DiscountEntity discount = await _repositoryManager.DiscountRepository.GetValidDiscountAsync(discountCode, detail.ProductId, cancellationToken);
        if (discount.AppliedDiscounts == null || discount.AppliedDiscounts.Count(x => x.UserId == userId) * detail.Quantity >= discount.MaxTimesApply)
        {
            throw new Exception("You have already exhausted the maximum use of this discount");
        }
        AppliedDiscountEntity appliedDiscount =
            discount.AppliedDiscounts.FirstOrDefault(x => x.PurchaseNumber == purchaseNumber) ?? throw new Exception("Discount not found");
        appliedDiscount.DiscountCode = discountCode;
        appliedDiscount.AppliedDate = DateTimeOffset.UtcNow;
        _repositoryManager.DiscountRepository.UpdateAppliedDiscount(appliedDiscount);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        ValidDiscountResponse validDiscountResponse = discount.Adapt<ValidDiscountResponse>();
        return validDiscountResponse;
    }
}