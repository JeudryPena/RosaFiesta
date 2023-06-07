using Contracts.Model.Product;
using Contracts.Model.Product.Response;

namespace Services.Abstractions;

public interface ISupplierService
{
	Task<IEnumerable<ManagementSuppliers>> GetAllAsync(CancellationToken cancellationToken = default);
	Task<SupplierResponse> GetByIdAsync(Guid supplierId, CancellationToken cancellationToken = default);
	Task<SupplierResponse> CreateAsync(string userId, SupplierDto supplierDto, CancellationToken cancellationToken = default);
	Task<SupplierResponse> UpdateAsync(string userId, Guid supplierId, SupplierDto supplierDto, CancellationToken cancellationToken = default);
	Task DeleteAsync(string userId, Guid supplierId, CancellationToken cancellationToken = default);
}