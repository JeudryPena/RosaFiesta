using Domain.Entities.Product;

namespace Domain.IRepository;

public interface IWarrantyRepository
{
	void Delete(WarrantyEntity warranty);
	Task<IEnumerable<WarrantyEntity>> GetAllAsync(CancellationToken cancellationToken = default);
	Task<WarrantyEntity> GetByIdAsync(Guid warrantyId, CancellationToken cancellationToken = default);
	Task<IEnumerable<WarrantyEntity>> GetWarrantiesList(CancellationToken cancellationToken = default);
	Task<IEnumerable<WarrantyEntity>> GetAllManagementAsync(CancellationToken cancellationToken = default);
	void Insert(WarrantyEntity warrantyEntity);
	void Update(WarrantyEntity warranty);
	Task<WarrantyEntity> GetPreviewAsync(Guid warrantyId, CancellationToken cancellationToken);
	Task<Guid?> GetPreviewByProductIdAsync(Guid warrantyId, CancellationToken cancellationToken);
	Task<Guid?> GetIdByProductId(Guid newDetailProductId, CancellationToken cancellationToken);
}