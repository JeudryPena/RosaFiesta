namespace Domain.Entities;

public class BaseEntity
{
	public bool IsDeleted { get; set; } = false;
	public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
	public DateTimeOffset? UpdatedAt { get; set; }
}
