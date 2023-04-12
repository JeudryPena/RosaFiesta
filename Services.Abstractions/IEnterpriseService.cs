using Contracts.Model.Enterprise;
using Contracts.Model.Enterprise.Response;

namespace Services.Abstractions;

public interface IEnterpriseService
{
    Task<IEnumerable<DepartmentPreviewResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<EmployePreviewResponse>> GetAllEmployeesPreview(CancellationToken cancellationToken = default);
    Task<DepartmentResponse> GetDepartmentAsync(int departmentId, CancellationToken cancellationToken = default);
    Task<EmployeeResponse> GetEmployeeAsync(Guid employeeId, CancellationToken cancellationToken = default);
    Task<DepartmentResponse> CreateAsync(string userId, DepartmentDto departmentDto, CancellationToken cancellationToken = default);
    Task<EmployeeResponse> CreateEmployeeAsync(string userId, EmployeeDto employeeDto, CancellationToken cancellationToken = default);
    Task<DepartmentResponse> UpdateAsync(string userId, int departmentId, DepartmentDto departmentDto, CancellationToken cancellationToken = default);
    Task<EmployeeResponse> UpdateEmployeeAsync(string userId, Guid employeeId, EmployeeDto employeeDto, CancellationToken cancellationToken = default);
    Task DeleteAsync(string userId, int departmentId, CancellationToken cancellationToken = default);
    Task DeleteEmployeeAsync(string userId, Guid employeeId, CancellationToken cancellationToken = default);
}