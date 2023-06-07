namespace Contracts.Model.Security.Response;

public class ActionLogResponse
{
    public Guid Id { get; set; }
    public string ActivityType { get; set; }
    public string UserId { get; set; }
    public string Action { get; set; }
    public DateTimeOffset Timestamp { get; set; }
    public string ActivityId { get; set; }
}