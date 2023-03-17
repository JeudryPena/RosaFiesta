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

    public async Task<OrderResponse> OrderPurchaseAsync(string userId, Guid payMethodId, OrderDto orderDto,
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
            order.Details = cart.Details;
            if (cart.Details == null) throw new Exception("Cart is empty");
            foreach (PurchaseDetailEntity detail in cart.Details)
            {
                var product =
                    await _repositoryManager.ProductRepository.GetByIdAsync(detail.ProductId, cancellationToken);
                if (detail.ProductId == null) throw new Exception("Product not found");
                if (product.QuantityAvaliable < detail.Quantity)
                {
                    throw new Exception("You can't add more than the quantity available");
                }
                
                product.QuantityAvaliable -= detail.Quantity;
                product.Stock = productStock(detail.Product.QuantityAvaliable);
                products.Add(product);
            }
            _repositoryManager.CartRepository.DeleteDetails(cart.Details);
        }
        _repositoryManager.ProductRepository.UpdateRange(products);
        _repositoryManager.OrderRepository.CreateAsync(order);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        OrderResponse orderResponse = order.Adapt<OrderResponse>();
        foreach (var e in order.Details)
        {
            orderResponse.AmmountPaid += e.UnitPrice * e.Quantity;
        }
        return orderResponse;
    }
    
    private StockStatusType productStock(int? productQuantityAvaliable)
    {
        if (productQuantityAvaliable <= 0)
            return StockStatusType.OutOfStock;
        if (productQuantityAvaliable <= 5)
            return StockStatusType.LowStock;
        return StockStatusType.InStock;
    }
}