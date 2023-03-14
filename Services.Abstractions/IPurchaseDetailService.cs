using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface IPurchaseDetailService
{
    Task<PurchaseDetailResponse> GetAllAsync(CancellationToken cancellationToken = default);
    Task<PurchaseDetailResponse> GetByIdAsync(int detailId, CancellationToken cancellationToken = default);

    Task<PurchaseDetailResponse> CreateAsync(PurchaseDetailDto purchaseDetailDto, string? userId, CancellationToken cancellationToken = default);
    Task<PurchaseDetailResponse> UpdateAsync(int detailId, PurchaseDetailDto purchaseDetailDto, string? userId, CancellationToken cancellationToken = default);
    Task DeleteAsync(int detailId, CancellationToken cancellationToken = default);
}