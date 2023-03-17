using Contracts.Model.Product;
using Contracts.Model.Product.Response;
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
        IEnumerable<OrderResponse> billResponse = orders.Adapt<IEnumerable<OrderResponse>>();
        return billResponse;
    }

    public async Task<OrderResponse> GetByIdAsync(int billId, CancellationToken cancellationToken = default) {
        OrderEntity order = await _repositoryManager.OrderRepository.GetByIdAsync(billId, cancellationToken);
        OrderResponse billResponse = order.Adapt<OrderResponse>();
        return billResponse;
    }
    

    public async Task<OrderResponse> UpdateAsync(int billId, OrderDto orderDto,
        CancellationToken cancellationToken = default) {
        OrderEntity order = await _repositoryManager.OrderRepository.GetByIdAsync(billId, cancellationToken);
        order = orderDto.Adapt(order);
        _repositoryManager.OrderRepository.Update(order);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        OrderResponse billResponse = order.Adapt<OrderResponse>();
        return billResponse;
    }

    public async Task DeleteAsync(int billId, CancellationToken cancellationToken = default) {
        OrderEntity order = await _repositoryManager.OrderRepository.GetByIdAsync(billId, cancellationToken);
        _repositoryManager.OrderRepository.Delete(order);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<OrderResponse> OrderPurchaseAsync(string userId, Guid payMethodId, string? discountCode,
        OrderDto orderDto,
        CancellationToken cancellationToken = default)
    {
        PayMethodEntity payMethod = await _repositoryManager.PayMethodRepository.GetByIdAsync(payMethodId, cancellationToken);
        if (payMethod == null) throw new Exception("Pay method not found");
        OrderEntity order = orderDto.Adapt<OrderEntity>();
        order.PaymentDate = DateTimeOffset.UtcNow;
        order.PayMethodId = payMethod.Id;
        order.UserId = userId;
        CartEntity cart = await _repositoryManager.CartRepository.GetByIdAsync(userId, cancellationToken);
        List<ProductEntity> products = new();
        if (cart.Details != null)
        {
            if (discountCode != null)
            {
                DiscountEntity discount =
                    await _repositoryManager.DiscountRepository.GetByIdAsync(discountCode, cancellationToken);
                cart.Details = cart.Details.Where(x => x.DiscountId == discountCode).Select(x =>
                {
                    x.UnitPrice = x.Product.Price - discount.Discount;
                    return x;
                }).ToList();
                if (discount.AppliedDiscounts == null)
                    throw new Exception("Discount not found");
                var appliedDiscounts = discount.AppliedDiscounts
                    .FirstOrDefault(x => x.UserId == userId && x.DiscountCode == discountCode) ?? throw new Exception("Discount not found");
                if (appliedDiscounts.TimesApplied >= discount.MaxTimesApply)
                    throw new Exception("You can't apply this discount anymore");
                appliedDiscounts.TimesApplied ++;
                _repositoryManager.DiscountRepository.UpdateAppliedDiscount(appliedDiscounts);
            }

            foreach (PurchaseDetailEntity detail in cart.Details)
            {
                ProductEntity product =
                    await _repositoryManager.ProductRepository.GetByIdAsync(detail.ProductId, cancellationToken);
                if (detail.ProductId == null) throw new Exception("Product not found");
                if (product.QuantityAvaliable < detail.Quantity)
                {
                    throw new Exception("You can't add more than the quantity available");
                }
                product.QuantityAvaliable -= detail.Quantity;
                product.Stock = ProductStock(detail.Product.QuantityAvaliable);
                products.Add(product);
            }
            _repositoryManager.CartRepository.DeleteDetails(cart.Details);
        }
        _repositoryManager.ProductRepository.UpdateRange(products);
        _repositoryManager.OrderRepository.CreateAsync(order);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        OrderResponse orderResponse = order.Adapt<OrderResponse>();
        return orderResponse;
    }

    public async Task<ValidDiscountResponse> ApplyDiscountAsync(string userId, string productId, string discountCode, CancellationToken cancellationToken)
    {
        DiscountEntity discount = await _repositoryManager.DiscountRepository.GetValidDiscountAsync(discountCode, productId, cancellationToken) ?? throw new Exception("Discount not found");
        AppliedDiscountEntity discountApplied =
            await _repositoryManager.DiscountRepository.GetAppliedDiscount(userId, discountCode, cancellationToken);
        if (discountApplied.TimesApplied >= discount.MaxTimesApply)
            throw new Exception("You have already exhausted the maximum use of this discount");
        CartEntity cart = await _repositoryManager.CartRepository.GetByIdAsync(userId, cancellationToken);
        if (cart.Details == null) throw new Exception("Cart is empty");
        cart.Details = cart.Details.Where(x => x.ProductId == productId).Select(x =>
        {
            x.DiscountId = discountCode;
            return x;
        }).ToList();
        _repositoryManager.PurchaseDetailRepository.UpdateRange(cart.Details);
        _repositoryManager.DiscountRepository.UpdateAppliedDiscount(discountApplied);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        ValidDiscountResponse validDiscountResponse = discount.Adapt<ValidDiscountResponse>();
        return validDiscountResponse;
    }

    private StockStatusType ProductStock(int? productQuantityAvaliable)
    {
        if (productQuantityAvaliable <= 0)
            return StockStatusType.OutOfStock;
        if (productQuantityAvaliable <= 5)
            return StockStatusType.LowStock;
        return StockStatusType.InStock;
    }
}