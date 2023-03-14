using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Domain.Entities.Product.UserInteract;
using Domain.IRepository;
using Mapster;
using Services.Abstractions;

namespace Services;

internal sealed class PurchaseDetailService : IPurchaseDetailService {
    private readonly IRepositoryManager _repositoryManager;

    public PurchaseDetailService(IRepositoryManager repositoryManager) {
        _repositoryManager = repositoryManager;
    }

    public async Task<PurchaseDetailResponse> GetAllAsync(CancellationToken cancellationToken = default) {
        IEnumerable<PurchaseDetailEntity> purchaseDetails = await _repositoryManager.PurchaseDetailRepository.GetAllAsync(cancellationToken);
        var purchaseDetailResponse = purchaseDetails.Adapt<PurchaseDetailResponse>();
        return purchaseDetailResponse;
    }

    public async Task<PurchaseDetailResponse> GetByIdAsync(int detailId, CancellationToken cancellationToken = default) {
        PurchaseDetailEntity purchaseDetail = await _repositoryManager.PurchaseDetailRepository.GetByIdAsync(detailId, cancellationToken);
        var purchaseDetailResponse = purchaseDetail.Adapt<PurchaseDetailResponse>();
        return purchaseDetailResponse;
    }

    public async Task<PurchaseDetailResponse> CreateAsync(PurchaseDetailDto purchaseDetailDto, string? userId, CancellationToken cancellationToken = default) {
        PurchaseDetailEntity purchaseDetail = purchaseDetailDto.Adapt<PurchaseDetailEntity>();
        purchaseDetail.CreatedBy = userId;
        purchaseDetail.CreatedAt = DateTimeOffset.UtcNow;
        purchaseDetail.UnitPrice = purchaseDetail.Product.Price;
        _repositoryManager.PurchaseDetailRepository.CreateAsync(purchaseDetail);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        var purchaseDetailResponse = purchaseDetail.Adapt<PurchaseDetailResponse>();
        purchaseDetailResponse.PurchaseTotal = purchaseDetail.UnitPrice * purchaseDetail.Quantity;
        return purchaseDetailResponse;
    }

    public async Task<PurchaseDetailResponse> UpdateAsync(int detailId, PurchaseDetailDto purchaseDetailDto, string? userId,
         CancellationToken cancellationToken = default) {
        PurchaseDetailEntity purchaseDetail = await _repositoryManager.PurchaseDetailRepository.GetByIdAsync(detailId, cancellationToken);
        purchaseDetail.Quantity = purchaseDetailDto.Quantity;
        purchaseDetail.UnitPrice = purchaseDetailDto.UnitPrice;
        purchaseDetail.DiscountId = purchaseDetailDto.DiscountApplied;
        purchaseDetail.UpdatedBy = userId;
        purchaseDetail.UpdatedAt = DateTimeOffset.UtcNow;
        _repositoryManager.PurchaseDetailRepository.Update(purchaseDetail);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        var purchaseDetailResponse = purchaseDetail.Adapt<PurchaseDetailResponse>();
        purchaseDetailResponse.PurchaseTotal = purchaseDetail.UnitPrice * purchaseDetail.Quantity;
        return purchaseDetailResponse;
    }

    public async Task DeleteAsync(int detailId, CancellationToken cancellationToken = default) {
        PurchaseDetailEntity purchaseDetail = await _repositoryManager.PurchaseDetailRepository.GetByIdAsync(detailId, cancellationToken);
        _repositoryManager.PurchaseDetailRepository.Delete(purchaseDetail);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}