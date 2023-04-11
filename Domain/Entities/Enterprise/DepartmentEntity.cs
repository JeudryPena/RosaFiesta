namespace Domain.Entities.Enterprise;

public class DepartmentEntity : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public int Floor { get; set; } 
    public string Description { get; set; } = String.Empty;
    public ICollection<EmployeeEntity>? Employees { get; set; }
}