namespace Domain.Entities.Enterprise;

public class EmployeeEntity: BaseEntity
{
    public string FullName { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Phone { get; set; } = String.Empty;
    public Guid DepartmentId { get; set; }
    public DepartmentEntity DepartmentEntity { get; set; } = new();
}