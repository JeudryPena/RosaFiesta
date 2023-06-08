namespace Contracts.Model;

public class BaseResponse
{
	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset? UpdatedAt { get; set; }
}
