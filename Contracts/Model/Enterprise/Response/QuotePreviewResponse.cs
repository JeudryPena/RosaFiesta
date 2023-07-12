namespace Contracts.Model.Enterprise.Response;

public class QuotePreviewResponse : BaseResponse
{
	public Guid Id { get; set; }
	public string CustomerName { get; set; }
	public string ContactNumber { get; set; }
	public string EventName { get; set; }
	public DateTimeOffset EventDate { get; set; }
	public string Location { get; set; }
	public string? UserId { get; set; }
}