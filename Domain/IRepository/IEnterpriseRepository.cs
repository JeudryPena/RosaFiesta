using Domain.Entities.Enterprise;

namespace Domain.IRepository;

public interface IEnterpriseRepository
{
    Task<IEnumerable<DepartmentEntity>> GetDepartmentsAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<EmployeeEntity>> GetEmployeesAsync(CancellationToken cancellationToken = default);
    Task<DepartmentEntity> GetDepartmentAsync(int departmentId, CancellationToken cancellationToken = default);
    Task<EmployeeEntity> GetEmployeeAsync(Guid employeeId, CancellationToken cancellationToken);
    void CreateDepartment(DepartmentEntity departmentEntity);
    void CreateEmployee(EmployeeEntity employeeEntity);
    void UpdateDepartment(DepartmentEntity departmentEntity);
    void UpdateEmployee(EmployeeEntity employeeEntity);
    void DeleteDepartment(DepartmentEntity departmentAsync);
    void DeleteEmployee(EmployeeEntity employeeEntity);
}