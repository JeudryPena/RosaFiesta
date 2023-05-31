using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public abstract class BaseEntity
{
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; set; }
    [StringLength(36, MinimumLength = 32)]
    public string? CreatedBy { get; set; } = "System";
    [StringLength(36, MinimumLength = 32)]
    public string? UpdatedBy { get; set; }
}