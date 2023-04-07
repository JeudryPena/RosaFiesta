using Contracts.Model.Product;
using Contracts.Model.Product.Response;

using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;
using Domain.IRepository;

using Mapster;

using Services.Abstractions;

namespace Services;

internal sealed class DiscountService : IDiscountService {
    private readonly IRepositoryManager _repositoryManager;

    public DiscountService(IRepositoryManager repositoryManager) {
        _repositoryManager = repositoryManager;
    }

    public async Task<IEnumerable<DiscountResponse>> GetAllAsync(CancellationToken cancellationToken = default) {
        IEnumerable<DiscountEntity> discounts = await _repositoryManager.DiscountRepository.GetAllAsync(cancellationToken);
        var discountResponse = discounts.Adapt<IEnumerable<DiscountResponse>>();
        return discountResponse;
    }

    public async Task<DiscountResponse> GetDiscountAsync(string discountId,
        CancellationToken cancellationToken = default) {
        DiscountEntity discount = await _repositoryManager.DiscountRepository.GetByIdAsync(discountId, cancellationToken);
        var discountResponse = discount.Adapt<DiscountResponse>();
        return discountResponse;
    }

    public async Task<DiscountResponse> CreateDiscountAsync(string? userId, DiscountDto discount, CancellationToken cancellationToken = default) {
        var discountEntity = discount.Adapt<DiscountEntity>();
        discountEntity.CreatedBy = userId;
        discountEntity.CreatedAt = DateTimeOffset.UtcNow;
        discountEntity.ProductsDiscounts = discount.ProductsDiscount.Select(d => new ProductsDiscountsEntity()
        {
            DiscountCode = discountEntity.DiscountCode,
            ProductId = d.ProductCode ?? null,
            OptionId = d.OptionId ?? null
        }).ToList();
        
        _repositoryManager.DiscountRepository.Insert(discountEntity);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        var discountResponse = discountEntity.Adapt<DiscountResponse>();
        return discountResponse;
    }

    public async Task<DiscountResponse> UpdateDiscountAsync(string? userId, string discountId,
        DiscountDto discountDto,
        CancellationToken cancellationToken = default) {
        DiscountEntity discount = await _repositoryManager.DiscountRepository.GetByIdAsync(discountId, cancellationToken);
        discount.Adapt(discountDto);
        discount.UpdatedBy = userId;
        discount.UpdatedAt = DateTimeOffset.UtcNow;
        _repositoryManager.DiscountRepository.Update(discount);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        return discount.Adapt<DiscountResponse>();
    }

    public async Task DeleteDiscountAsync(string discountId, CancellationToken cancellationToken = default) {
        DiscountEntity discount = await _repositoryManager.DiscountRepository.GetDiscountAsync(discountId, cancellationToken);
        _repositoryManager.DiscountRepository.Delete(discount);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}