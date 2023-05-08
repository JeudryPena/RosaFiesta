using System.Net;
using System.Security.Claims;
using Contracts.Model.Enterprise;
using Contracts.Model.Enterprise.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class EnterpriseController: ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public EnterpriseController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpGet("employees")]
    public async Task<IActionResult> GetEmployees(CancellationToken cancellationToken)
    {
        IEnumerable<EmployePreviewResponse> employees = await _serviceManager.EnterpriseService.GetAllEmployeesPreview(cancellationToken);
        return Ok(employees);
    }

    [HttpGet("employees/{employeeId:guid}")]
    public async Task<IActionResult> GetEmployeeById(Guid employeeId, CancellationToken cancellationToken)
    {
        EmployeeResponse employee = await _serviceManager.EnterpriseService.GetEmployeeAsync(employeeId, cancellationToken);
        return Ok(employee);
    }

    [HttpPost("employees")]
    public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDto employeeDto, CancellationToken cancellationToken)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        EmployeeResponse employee = await _serviceManager.EnterpriseService.CreateEmployeeAsync(userId, employeeDto, cancellationToken);
        return Ok(employee);
    }

    [HttpPut("employees/{employeeId:guid}")]
    public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeDto employeeDto, CancellationToken cancellationToken, Guid employeeId)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        EmployeeResponse employee = await _serviceManager.EnterpriseService.UpdateEmployeeAsync(userId, employeeId, employeeDto, cancellationToken);
        return Ok(employee);
    }

    [HttpDelete("employees/{employeeId:guid}")]
    public async Task<IActionResult> DeleteEmployee(Guid employeeId, CancellationToken cancellationToken)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return StatusCode((int) HttpStatusCode.Unauthorized);
        await _serviceManager.EnterpriseService.DeleteEmployeeAsync(userId, employeeId, cancellationToken);
        return Ok();
    }
}