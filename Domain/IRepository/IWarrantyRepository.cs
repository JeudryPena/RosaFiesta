using Domain.Entities.Product;

namespace Domain.IRepository;

public interface IWarrantyRepository
{
    Task<IEnumerable<WarrantyEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<WarrantyEntity> GetByIdAsync(Guid warrantyId, CancellationToken cancellationToken = default);
    void Insert(WarrantyEntity warrantyEntity);
    void Update(WarrantyEntity warranty);
    void Delete(WarrantyEntity warranty);
}