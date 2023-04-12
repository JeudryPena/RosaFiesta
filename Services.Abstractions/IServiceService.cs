using Contracts.Model.Enterprise;
using Contracts.Model.Enterprise.Response;

namespace Services.Abstractions;

public interface IServiceService
{
    Task<IEnumerable<ServiceResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ServiceResponse> GetServiceAsync(Guid serviceId, CancellationToken cancellationToken = default);
    Task<ServiceResponse> CreateAsync(string userId, ServiceDto serviceDto, CancellationToken cancellationToken = default);
    Task<ServiceResponse> UpdateAsync(string userId, Guid serviceId, ServiceUpdateDto serviceDto,
        CancellationToken cancellationToken = default);
    Task<ServiceResponse> AdjustOptionQuantityAsync(string userId, Guid serviceId, int count,
        CancellationToken cancellationToken = default);
    Task DeleteAsync(string userId, Guid serviceId, CancellationToken cancellationToken);
}