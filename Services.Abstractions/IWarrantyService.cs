using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface IWarrantyService
{
    Task<IEnumerable<WarrantyResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<WarrantyResponse> GetWarrantyAsync(Guid warrantyId, CancellationToken cancellationToken = default);
    Task<WarrantyResponse> CreateWarrantyAsync(string? username, WarrantyDto warranty, CancellationToken cancellationToken = default);
    Task<WarrantyResponse> UpdateWarrantyAsync(string? username, Guid warrantyId, WarrantyDto warrantyDto, CancellationToken cancellationToken = default);
    Task DeleteWarrantyAsync(Guid warrantyId, CancellationToken cancellationToken = default);
    Task<WarrantyResponse> UpdateWarrantyStatusAsync(string userId, Guid warrantyId, int warrantyStatus, CancellationToken cancellationToken = default);
}