using Contracts.Model.Security.Response;

namespace Services.Abstractions;

public interface IActionLogService
{
    Task<IEnumerable<ActionLogResponse>> GetActionLogsAsync(CancellationToken cancellationToken = default);
    Task<ActionLogResponse> GetActionLogByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<ActionLogResponse>> GetActionLogsByUserIdAsync(string userId, CancellationToken cancellationToken = default);
    Task<IEnumerable<ActionLogResponse>> GetActionLogsByFilterAsync(string activityType, int? action, CancellationToken cancellationToken);
}