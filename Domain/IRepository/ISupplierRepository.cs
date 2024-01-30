using Domain.Entities.Product;

namespace Domain.IRepository;

public interface ISupplierRepository
{
	void Delete(SupplierEntity supplier);
	Task<IEnumerable<SupplierEntity>> GetAllAsync(CancellationToken cancellationToken = default);
	Task<SupplierEntity> GetByIdAsync(Guid supplierId, CancellationToken cancellationToken = default);
	Task<IEnumerable<SupplierEntity>> GetSuppliersAsync(CancellationToken cancellationToken = default);
	void Insert(SupplierEntity supplier);
	void Update(SupplierEntity supplier);
	Task VerifyUniqueEmail(string? supplierEmail, CancellationToken cancellationToken);
	Task VerifyUniquePhone(string? supplierPhone, CancellationToken cancellationToken);
	Task VerifyUniqueEmailUpdate(Guid supplierId, string? supplierEmail, CancellationToken cancellationToken);
	Task VerifyUniquePhoneUpdate(Guid supplierId, string? supplierPhone, CancellationToken cancellationToken);
}