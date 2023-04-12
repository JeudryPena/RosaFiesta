using Domain.Entities.Enterprise;
using Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

internal sealed class EnterpriseRepository: IEnterpriseRepository
{
    private readonly RosaFiestaContext _context;
    
    public EnterpriseRepository(RosaFiestaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DepartmentEntity>> GetDepartmentsAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<DepartmentEntity> departmentEntities = await _context.Departments
            .ToListAsync(cancellationToken);
        return departmentEntities;
    }

    public async Task<IEnumerable<EmployeeEntity>> GetEmployeesAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<EmployeeEntity> employeeEntities = await _context.Employees
            .ToListAsync(cancellationToken);
        return employeeEntities;
    }

    public async Task<DepartmentEntity> GetDepartmentAsync(int departmentId, CancellationToken cancellationToken = default)
    {
        DepartmentEntity? departmentEntity = await _context.Departments.Include(x => x.Employees).FirstOrDefaultAsync(x => x.Id == departmentId, cancellationToken);
        if(departmentEntity is null)
            throw new Exception("Department not found");
        return departmentEntity;
    }

    public async Task<EmployeeEntity> GetEmployeeAsync(Guid employeeId, CancellationToken cancellationToken)
    {
        EmployeeEntity? employeeEntity = await _context.Employees.FirstOrDefaultAsync(x => x.Id == employeeId, cancellationToken);
        if(employeeEntity is null)
            throw new Exception("Employee not found");
        return employeeEntity;
    }

    public void CreateDepartment(DepartmentEntity departmentEntity)
    => _context.Departments.Add(departmentEntity);

    public void CreateEmployee(EmployeeEntity employeeEntity)
    => _context.Employees.Add(employeeEntity);

    public void UpdateDepartment(DepartmentEntity departmentEntity)
    => _context.Departments.Update(departmentEntity);

    public void UpdateEmployee(EmployeeEntity employeeEntity)
    => _context.Employees.Update(employeeEntity);

    public void DeleteDepartment(DepartmentEntity departmentAsync)
    => _context.Departments.Remove(departmentAsync);

    public void DeleteEmployee(EmployeeEntity employeeEntity)
    => _context.Employees.Remove(employeeEntity);
}