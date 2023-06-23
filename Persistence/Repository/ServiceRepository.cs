using Domain.Entities.Enterprise;
using Domain.IRepository;

using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

internal sealed class ServiceRepository : IServiceRepository
{
	private readonly RosaFiestaContext _context;

	public ServiceRepository(RosaFiestaContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<ServiceEntity>> GetAllAsync(CancellationToken cancellationToken = default) => await _context.Services.ToListAsync(cancellationToken);

	public async Task<ServiceEntity> GetAsync(Guid serviceId, CancellationToken cancellationToken = default)
	{
		ServiceEntity? service = await _context.Services.FindAsync(serviceId);
		if (service == null)
			throw new Exception("Service not found");
		return service;
	}

	public void Create(ServiceEntity service)
	=> _context.Services.Add(service);

	public void Update(ServiceEntity service)
	=> _context.Services.Update(service);

	public async Task<ServiceEntity> AvaliableService(Guid serviceId, int quantity, CancellationToken cancellationToken)
	{
		ServiceEntity? service = await _context.Services.FindAsync(serviceId, cancellationToken);
		if (service == null)
			throw new Exception("Service not found");
		if (service.QuantityAvaliable < quantity)
			throw new Exception("You can't add more than the quantity available");
		service.QuantityAvaliable -= quantity;
		_context.Services.Update(service);
		return service;
	}

	public async Task RestoreQuantity(Guid serviceId, int quantity, CancellationToken cancellationToken = default)
	{
		ServiceEntity? service = await _context.Services.FindAsync(serviceId, cancellationToken);
		if (service == null)
			throw new Exception("Service not found");
		service.QuantityAvaliable += quantity;
		_context.Services.Update(service);
	}
}