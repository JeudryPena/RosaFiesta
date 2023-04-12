using Domain.Entities.Security;

namespace Domain.IRepository;

public interface IActionLogRepository
{
    void Create(ActionLogEntity log);
    Task<IEnumerable<ActionLogEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ActionLogEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<ActionLogEntity>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default);
    Task<IEnumerable<ActionLogEntity>> GetByFilterAsync(string activityType, int? action, CancellationToken cancellationToken = default);
}