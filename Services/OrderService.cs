using Contracts.Model.Product;
using Contracts.Model.Product.Response;

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
}