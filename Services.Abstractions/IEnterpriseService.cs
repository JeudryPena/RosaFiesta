using Contracts.Model.Enterprise;
using Contracts.Model.Enterprise.Response;

namespace Services.Abstractions;

public interface IEnterpriseService
{
    Task<IEnumerable<EmployePreviewResponse>> GetAllEmployeesPreview(CancellationToken cancellationToken = default);
    Task<EmployeeResponse> GetEmployeeAsync(Guid employeeId, CancellationToken cancellationToken = default);
    Task<EmployeeResponse> CreateEmployeeAsync(string userId, EmployeeDto employeeDto, CancellationToken cancellationToken = default);
    Task<EmployeeResponse> UpdateEmployeeAsync(string userId, Guid employeeId, EmployeeDto employeeDto, CancellationToken cancellationToken = default);
    Task DeleteEmployeeAsync(string userId, Guid employeeId, CancellationToken cancellationToken = default);
}