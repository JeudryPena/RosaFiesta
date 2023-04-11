using Domain.Entities.Security.Helper;

namespace Domain.Entities.Security;

public class ActivityLogEntity
{
    public Guid Id { get; set; }
    public Activities ActivityType { get; set; }
    public string Description { get; set; }
    public string UserName { get; set; }
    public ActivityAction Action { get; set; }
    public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;
}