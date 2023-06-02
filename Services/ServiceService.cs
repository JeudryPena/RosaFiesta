using Contracts.Model.Enterprise;
using Contracts.Model.Enterprise.Response;

using Domain.Entities.Enterprise;
using Domain.Entities.Security;
using Domain.Entities.Security.Helper;
using Domain.IRepository;

using Mapster;

using Services.Abstractions;

namespace Services;

internal sealed class ServiceService : IServiceService
{
    private readonly IRepositoryManager _repositoryManager;

    public ServiceService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<IEnumerable<ServiceResponse>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<ServiceEntity> services = await _repositoryManager.ServiceRepository.GetAllAsync(cancellationToken);
        IEnumerable<ServiceResponse> serviceResponses = services.Adapt<IEnumerable<ServiceResponse>>();
        return serviceResponses;
    }

    public async Task<ServiceResponse> GetServiceAsync(Guid serviceId, CancellationToken cancellationToken = default)
    {
        ServiceEntity service = await _repositoryManager.ServiceRepository.GetAsync(serviceId, cancellationToken);
        ServiceResponse serviceResponse = service.Adapt<ServiceResponse>();
        return serviceResponse;
    }

    public async Task<ServiceResponse> CreateAsync(string userId, ServiceDto serviceDto, CancellationToken cancellationToken = default)
    {
        ServiceEntity service = serviceDto.Adapt<ServiceEntity>();
        _repositoryManager.ServiceRepository.Create(service);
        ActionLogEntity actionLog = new()
        {
            UserId = userId,
            ActivityType = Activities.Service,
            Action = ActivityAction.Created,
        };
        _repositoryManager.ActionLogRepository.Create(actionLog);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        ServiceResponse serviceResponse = service.Adapt<ServiceResponse>();
        return serviceResponse;
    }

    public async Task<ServiceResponse> UpdateAsync(string userId, Guid serviceId, ServiceUpdateDto serviceDto,
        CancellationToken cancellationToken = default)
    {
        ServiceEntity service = await _repositoryManager.ServiceRepository.GetAsync(serviceId, cancellationToken);
        service = serviceDto.Adapt(service);
        if (serviceDto.Quantity != null)
        {
            int count = (int)(serviceDto.Quantity - service.Quantity);
            service.Quantity = service.Quantity;
            service.QuantityAvaliable += count;
        }
        ActionLogEntity actionLog = new()
        {
            UserId = userId,
            ActivityType = Activities.Service,
            Action = ActivityAction.Updated,
        };
        _repositoryManager.ActionLogRepository.Create(actionLog);
        _repositoryManager.ServiceRepository.Update(service);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        ServiceResponse serviceResponse = service.Adapt<ServiceResponse>();
        return serviceResponse;
    }

    public async Task<ServiceResponse> AdjustOptionQuantityAsync(string userId, Guid serviceId, int count,
        CancellationToken cancellationToken = default)
    {
        ServiceEntity service = await _repositoryManager.ServiceRepository.GetAsync(serviceId, cancellationToken);
        service.Quantity += count;
        service.QuantityAvaliable += count;
        _repositoryManager.ServiceRepository.Update(service);
        ActionLogEntity actionLog = new()
        {
            UserId = userId,
            ActivityType = Activities.Service,
            Action = ActivityAction.Updated,
        };
        _repositoryManager.ActionLogRepository.Create(actionLog);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        ServiceResponse serviceResponse = service.Adapt<ServiceResponse>();
        return serviceResponse;
    }

    public async Task DeleteAsync(string userId, Guid serviceId, CancellationToken cancellationToken)
    {
        ServiceEntity service = await _repositoryManager.ServiceRepository.GetAsync(serviceId, cancellationToken);
        _repositoryManager.ServiceRepository.Delete(service);
        ActionLogEntity actionLog = new()
        {
            UserId = userId,
            ActivityType = Activities.Service,
            Action = ActivityAction.Deleted,
        };
        _repositoryManager.ActionLogRepository.Create(actionLog);
        await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}