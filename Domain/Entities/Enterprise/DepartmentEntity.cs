namespace Domain.Entities.Enterprise;

public class DepartmentEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public int Floor { get; set; } 
    public string Description { get; set; } = String.Empty;
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public ICollection<EmployeeEntity>? Employees { get; set; } 
}