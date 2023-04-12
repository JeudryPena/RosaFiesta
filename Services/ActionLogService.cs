using Contracts.Model.Security.Response;
using Domain.Entities.Security;
using Domain.IRepository;
using Mapster;
using Services.Abstractions;

namespace Services;

internal sealed class ActionLogService: IActionLogService
{
    private readonly IRepositoryManager _repositoryManager;
    
    public ActionLogService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }


    public async Task<IEnumerable<ActionLogResponse>> GetActionLogsAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<ActionLogEntity> actionLogs = await _repositoryManager.ActionLogRepository.GetAllAsync(cancellationToken);
        IEnumerable<ActionLogResponse> actionLogResponses = actionLogs.Adapt<IEnumerable<ActionLogResponse>>();
        return actionLogResponses;
    }

    public async Task<ActionLogResponse> GetActionLogByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        ActionLogEntity actionLog = await _repositoryManager.ActionLogRepository.GetByIdAsync(id, cancellationToken);
        ActionLogResponse actionLogResponse = actionLog.Adapt<ActionLogResponse>();
        return actionLogResponse;
    }

    public async Task<IEnumerable<ActionLogResponse>> GetActionLogsByUserIdAsync(string userId, CancellationToken cancellationToken = default)
    {
        IEnumerable<ActionLogEntity> actionLogs = await _repositoryManager.ActionLogRepository.GetByUserIdAsync(userId, cancellationToken);
        IEnumerable<ActionLogResponse> actionLogResponses = actionLogs.Adapt<IEnumerable<ActionLogResponse>>();
        return actionLogResponses;
    }

    public async Task<IEnumerable<ActionLogResponse>> GetActionLogsByFilterAsync(string activityType, int? action, CancellationToken cancellationToken)
    {
        IEnumerable<ActionLogEntity> actionLogs = await _repositoryManager.ActionLogRepository.GetByFilterAsync(activityType, action, cancellationToken);
        IEnumerable<ActionLogResponse> actionLogResponses = actionLogs.Adapt<IEnumerable<ActionLogResponse>>();
        return actionLogResponses;
    }
}