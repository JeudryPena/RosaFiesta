namespace Contracts.Model.Enterprise.Response;

public class DepartmentPreviewResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public DateTimeOffset CreatedAt { get; set; }
}