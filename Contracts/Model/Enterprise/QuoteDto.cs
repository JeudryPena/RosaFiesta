using Contracts.Model.Product.UserInteract;

namespace Contracts.Model.Enterprise;

public class QuoteDto
{
	public string CustomerName { get; set; }
	public string ContactNumber { get; set; }
	public string? ExtraInfo { get; set; }
	public string EventName { get; set; }
	public DateTimeOffset EventDate { get; set; }
	public DateTimeOffset CreatedAt { get; set; }
	public string Location { get; set; }
	public ICollection<PurchaseDetailDto> QuoteItems { get; set; }
}