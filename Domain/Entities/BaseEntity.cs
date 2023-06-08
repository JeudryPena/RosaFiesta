namespace Domain.Entities;

public class BaseEntity
{
	public bool IsDeleted { get; set; } = false;
	public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
	public DateTimeOffset? UpdatedAt { get; set; }
}
