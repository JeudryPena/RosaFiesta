using Domain.Entities.Enterprise;

namespace Domain.IRepository;

public interface IServiceRepository
{
	Task<IEnumerable<ServiceEntity>> GetAllAsync(CancellationToken cancellationToken = default);
	Task<ServiceEntity> GetAsync(Guid serviceId, CancellationToken cancellationToken = default);
	void Create(ServiceEntity service);
	void Update(ServiceEntity service);
	Task<ServiceEntity> AvaliableService(Guid serviceId, int qQuantity, CancellationToken cancellationToken = default);
	Task RestoreQuantity(Guid qServiceId, int qQuantity, CancellationToken cancellationToken = default);
	void Delete(ServiceEntity service);
}