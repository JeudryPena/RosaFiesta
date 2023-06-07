namespace Contracts.Model.Security.Response;

public class PaymentsPreviewResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PayMethodType { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public bool? IsDefault { get; set; }
}