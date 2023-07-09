using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface IWarrantyService
{
	Task<IEnumerable<WarrantyPreviewResponse>> GetAllAsync(CancellationToken cancellationToken = default);
	Task<WarrantyResponse> GetWarrantyAsync(Guid warrantyId, CancellationToken cancellationToken = default);
	Task CreateWarrantyAsync(string userId, WarrantyDto warranty, CancellationToken cancellationToken = default);
	Task UpdateWarrantyAsync(string userId, Guid warrantyId, WarrantyDto warrantyDto, CancellationToken cancellationToken = default);
	Task DeleteWarrantyAsync(string userId, Guid warrantyId, CancellationToken cancellationToken = default);
	Task UpdateWarrantyStatusAsync(string userId, Guid warrantyId, int warrantyStatus, CancellationToken cancellationToken = default);
	Task<IEnumerable<WarrantiesManagementResponse>> GetAllForManagementAsync(CancellationToken cancellationToken = default);
	Task DeleteWarrantyProductAsync(string userId, Guid warrantyId, Guid productId, CancellationToken cancellationToken = default);
	Task<IEnumerable<WarrantiesListResponse>> GetAllForAdminAsync(CancellationToken cancellationToken = default);
}