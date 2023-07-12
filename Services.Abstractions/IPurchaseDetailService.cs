using Contracts.Model.Product;
using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract;
using Contracts.Model.Product.UserInteract.Response;

namespace Services.Abstractions;

public interface IPurchaseDetailService
{
    Task<IEnumerable<PurchaseDetailResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<PurchaseDetailResponse> GetByIdAsync(Guid detailId, CancellationToken cancellationToken = default);
    Task<PurchaseDetailResponse> UpdateAsync(string userId, Guid detailId, PurchaseDetailDto purchaseDetailDto,
        CancellationToken cancellationToken = default);
    Task DeleteAsync(string userId, Guid detailId, CancellationToken cancellationToken = default);
}