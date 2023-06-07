using Domain.Entities.Product;

namespace Domain.IRepository;

public interface ISupplierRepository
{
	Task<IEnumerable<SupplierEntity>> GetAllAsync(CancellationToken cancellationToken = default);
	Task<SupplierEntity> GetByIdAsync(Guid supplierId, CancellationToken cancellationToken = default);
	void Insert(SupplierEntity supplier);
	void Update(SupplierEntity supplier);
}