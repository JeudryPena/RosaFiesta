namespace Domain.Entities;
public interface IAutoUpdate : ISoftDelete
{
	DateTimeOffset? UpdatedAt { get; set; }
}
