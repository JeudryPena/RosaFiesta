namespace Contracts.Model.Enterprise.Response;

public class DepartmentResponse : BaseResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public int Floor { get; set; } 
    public string Description { get; set; } = String.Empty;
    public ICollection<EmployePreviewResponse>? Employees { get; set; }
}