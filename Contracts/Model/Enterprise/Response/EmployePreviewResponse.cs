namespace Contracts.Model.Enterprise.Response;

public class EmployePreviewResponse
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public int DepartmentId { get; set; }
    public string JobTitle { get; set; }
    public string Photo { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}