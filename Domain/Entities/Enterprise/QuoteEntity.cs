using System.ComponentModel.DataAnnotations;

using Domain.Entities.Product.UserInteract;

namespace Domain.Entities.Enterprise;

public class QuoteEntity : BaseEntity, IAutoUpdate
{
	public Guid Id { get; set; }
	[StringLength(50, MinimumLength = 2)]
	public string CustomerName { get; set; }
	[StringLength(15, MinimumLength = 7)]
	public string ContactNumber { get; set; }
	[StringLength(5000, MinimumLength = 4)]
	public string? ExtraInfo { get; set; }
	[StringLength(320, MinimumLength = 7)]
	public string? Email { get; set; }
	[StringLength(50, MinimumLength = 2)]
	public string EventName { get; set; }
	public DateTimeOffset EventDate { get; set; }
	[StringLength(255, MinimumLength = 2)]
	public string Location { get; set; }
	public ICollection<PurchaseDetailEntity> QuoteItems { get; set; }
	public string? UserId { get; set; }
}