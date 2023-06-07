using System.ComponentModel.DataAnnotations;

using Domain.Entities.Security.Helper;

namespace Domain.Entities.Security;

public class ActionLogEntity
{
    public Guid Id { get; set; }
    [StringLength(12, MinimumLength = 3)]
    public string ActivityType { get; set; }
    [StringLength(36, MinimumLength = 32)]
    public string? UserId { get; set; }
    [StringLength(12, MinimumLength = 3)]
    public string ActivityId { get; set; }
    public ActivityAction Action { get; set; }
    public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;
}