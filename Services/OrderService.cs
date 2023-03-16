using Contracts.Model.Product;
using Contracts.Model.Product.Response;
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

    public async Task<IEnumerable<BillResponse>> GetAllAsync(CancellationToken cancellationToken = default) {
        IEnumerable<OrderEntity> orders = await _repositoryManager.OrderRepository.GetAllAsync(cancellationToken);
        IEnumerable<BillResponse> billResponse = orders.Adapt<IEnumerable<BillResponse>>();
        return billResponse;
    }

    public async Task<BillResponse> GetByIdAsync(int billId, CancellationToken cancellationToken = default) {
        OrderEntity order = await _repositoryManager.OrderRepository.GetByIdAsync(billId, cancellationToken);
        BillResponse billResponse = order.Adapt<BillResponse>();
        return billResponse;
    }

    public async Task<BillResponse> CreateAsync(OrderDto orderDto, CancellationToken cancellationToken = default) {
        OrderEntity order = orderDto.Adapt<OrderEntity>();
        order.PaymentDate = DateTimeOffset.UtcNow;
        _repositoryManager.OrderRepository.CreateAsync(order);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        BillResponse billResponse = order.Adapt<BillResponse>();
        return billResponse;
    }

    public async Task<BillResponse> UpdateAsync(int billId, OrderDto orderDto,
        CancellationToken cancellationToken = default) {
        OrderEntity order = await _repositoryManager.OrderRepository.GetByIdAsync(billId, cancellationToken);
        order = orderDto.Adapt(order);
        _repositoryManager.OrderRepository.Update(order);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        BillResponse billResponse = order.Adapt<BillResponse>();
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
        order.Details = cart.Details;
        if (cart.Details == null) throw new Exception("Cart is empty");
        foreach (PurchaseDetailEntity detail in cart.Details) {
            var product = await _repositoryManager.ProductRepository.GetByIdAsync(detail.ProductId, cancellationToken);
            if(detail.ProductId == null) throw new Exception("Product not found");
            if (product.QuantityAvaliable < detail.Quantity)
            {
                throw new Exception("You can't add more than the quantity available");
            }
            product.QuantityAvaliable -= detail.Quantity;
            product.Stock = productStock(detail.Product.QuantityAvaliable);
            _repositoryManager.ProductRepository.Update(product);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
        _repositoryManager.CartRepository.DeleteDetails(cart.Details);
        _repositoryManager.OrderRepository.CreateAsync(order);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        OrderResponse orderResponse = order.Adapt<OrderResponse>();
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