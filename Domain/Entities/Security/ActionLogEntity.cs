using Domain.Entities.Security.Helper;

namespace Domain.Entities.Security;

public class ActionLogEntity
{
    public Guid Id { get; set; }
    public string ActivityType { get; set; }
    public string? UserId { get; set; }
    public ActivityAction Action { get; set; }
    public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;
}