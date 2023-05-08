using Domain.Entities.Enterprise;

namespace Domain.IRepository;

public interface IEnterpriseRepository
{
    Task<IEnumerable<EmployeeEntity>> GetEmployeesAsync(CancellationToken cancellationToken = default);
    Task<EmployeeEntity> GetEmployeeAsync(Guid employeeId, CancellationToken cancellationToken);
    void CreateEmployee(EmployeeEntity employeeEntity);
    void UpdateEmployee(EmployeeEntity employeeEntity);
    void DeleteEmployee(EmployeeEntity employeeEntity);
}