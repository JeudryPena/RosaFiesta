using Contracts.Model.Security.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class ActionLogsController: ControllerBase
{
    private readonly IServiceManager _serviceManager;
    
    public ActionLogsController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetActionLogs(CancellationToken cancellationToken)
    {
        IEnumerable<ActionLogResponse> actionLogs = await _serviceManager.ActionLogService.GetActionLogsAsync(cancellationToken);
        return Ok(actionLogs);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetActionLogById(Guid id, CancellationToken cancellationToken)
    {
        ActionLogResponse actionLog = await _serviceManager.ActionLogService.GetActionLogByIdAsync(id, cancellationToken);
        return Ok(actionLog);
    }
    
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetActionLogsByUserId(string userId, CancellationToken cancellationToken)
    {
        IEnumerable<ActionLogResponse> actionLogs = await _serviceManager.ActionLogService.GetActionLogsByUserIdAsync(userId, cancellationToken);
        return Ok(actionLogs);
    }
    
    [HttpGet("filter")]
    public async Task<IActionResult> GetActionLogsByFilter(string ActivityType, int? Action, CancellationToken cancellationToken)
    {
        IEnumerable<ActionLogResponse> actionLogs = await _serviceManager.ActionLogService.GetActionLogsByFilterAsync(ActivityType, Action, cancellationToken);
        return Ok(actionLogs);
    }
    
}