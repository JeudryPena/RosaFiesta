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

    public async Task<IEnumerable<EmployeeEntity>> GetEmployeesAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<EmployeeEntity> employeeEntities = await _context.Employees
            .ToListAsync(cancellationToken);
        return employeeEntities;
    }

    public async Task<EmployeeEntity> GetEmployeeAsync(Guid employeeId, CancellationToken cancellationToken)
    {
        EmployeeEntity? employeeEntity = await _context.Employees.FirstOrDefaultAsync(x => x.Id == employeeId, cancellationToken);
        if(employeeEntity is null)
            throw new Exception("Employee not found");
        return employeeEntity;
    }
    
    public void CreateEmployee(EmployeeEntity employeeEntity)
    => _context.Employees.Add(employeeEntity);
    
    public void UpdateEmployee(EmployeeEntity employeeEntity)
    => _context.Employees.Update(employeeEntity);

    public void DeleteEmployee(EmployeeEntity employeeEntity)
    => _context.Employees.Remove(employeeEntity);
}