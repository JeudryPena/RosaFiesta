using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface ISupplierService
{
    Task<IEnumerable<SupplierResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<SupplierResponse> GetByIdAsync(Guid supplierId, CancellationToken cancellationToken = default);
    Task<SupplierResponse> CreateAsync(string? username, SupplierDto supplierDto, CancellationToken cancellationToken = default);
    Task<SupplierResponse> UpdateAsync(string? username, Guid supplierId, SupplierDto supplierDto,
        CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid supplierId, CancellationToken cancellationToken = default);
}