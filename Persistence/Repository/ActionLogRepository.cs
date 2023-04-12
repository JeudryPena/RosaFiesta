using Domain.Entities.Security;
using Domain.Entities.Security.Helper;
using Domain.Exceptions;
using Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

internal sealed class ActionLogRepository: IActionLogRepository
{
    private readonly RosaFiestaContext _context;
    
    public ActionLogRepository(RosaFiestaContext context)
    {
        _context = context;
    }

    public void Create(ActionLogEntity log)
    => _context.ActionLogs.Add(log);

    public async Task<IEnumerable<ActionLogEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<ActionLogEntity> actionLogs = await _context.ActionLogs.ToListAsync(cancellationToken);
        return actionLogs;
    }

    public async Task<ActionLogEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        ActionLogEntity? actionLog = await _context.ActionLogs.FindAsync(id, cancellationToken);
        if(actionLog is null)
            throw new NullReferenceException($"ActionLog with id {id} not found");
        return actionLog;
    }

    public async Task<IEnumerable<ActionLogEntity>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default)
    {
        IEnumerable<ActionLogEntity> actionLogs = await _context.ActionLogs.Where(log => log.UserId == userId).ToListAsync(cancellationToken);
        return actionLogs;
    }

    public async Task<IEnumerable<ActionLogEntity>> GetByFilterAsync(string activityType, int? action, CancellationToken cancellationToken = default)
    {
        IEnumerable<ActionLogEntity> actionLogs = await _context.ActionLogs.Where(log => log.ActivityType == activityType && (action == null || log.Action == (ActivityAction)action)).ToListAsync(cancellationToken);
        return actionLogs;
    }
}