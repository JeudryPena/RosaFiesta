using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract;
using Contracts.Model.Product.UserInteract.Response;

namespace Services.Abstractions;

public interface IPurchaseDetailService
{
    Task<IEnumerable<PurchaseDetailResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<PurchaseDetailResponse> GetByIdAsync(int detailId, CancellationToken cancellationToken = default);
    Task<PurchaseDetailResponse> UpdateAsync(int detailId, PurchaseDetailDto purchaseDetailDto, string? userId, CancellationToken cancellationToken = default);
    Task DeleteAsync(int detailId, CancellationToken cancellationToken = default);
}