using Domain.Entities.Security;

namespace Domain.Entities.Enterprise;

public class EmployeeEntity: BaseEntity
{
    public Guid Id { get; set; }
    public string FullName { get; set; } 
    public string Email { get; set; } 
    public string Phone { get; set; } 
    public int DepartmentId { get; set; }
    public DepartmentEntity DepartmentEntity { get; set; } = new();
    public string JobTitle { get; set; }
    public string Address { get; set; }
    public decimal Salary { get; set; }
    public string WorkingHours { get; set; }
    public string WorkingDays { get; set; }
    public string Resume { get; set; }
    public string Photo { get; set; }
}