using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface IWarrantyService
{
	Task<IEnumerable<WarrantyPreviewResponse>> GetAllAsync(CancellationToken cancellationToken = default);
	Task<WarrantyResponse> GetWarrantyAsync(Guid warrantyId, CancellationToken cancellationToken = default);
	Task<WarrantyResponse> CreateWarrantyAsync(string userId, WarrantyDto warranty, CancellationToken cancellationToken = default);
	Task<WarrantyResponse> UpdateWarrantyAsync(string userId, Guid warrantyId, WarrantyDto warrantyDto, CancellationToken cancellationToken = default);
	Task DeleteWarrantyAsync(string userId, Guid warrantyId, CancellationToken cancellationToken = default);
	Task<WarrantyResponse> UpdateWarrantyStatusAsync(string userId, Guid warrantyId, int warrantyStatus, CancellationToken cancellationToken = default);
	Task<IEnumerable<WarrantyResponse>> GetAllForManagementAsync(CancellationToken cancellationToken = default);
	Task DeleteWarrantyProductAsync(string userId, Guid warrantyId, Guid productId, CancellationToken cancellationToken = default);
	Task<IEnumerable<WarrantiesListResponse>> GetAllForAdminAsync(CancellationToken cancellationToken = default);
}