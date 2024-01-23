using System.ComponentModel.DataAnnotations;

using Domain.Entities.Product.UserInteract;

namespace Domain.Entities.Enterprise;

public class QuoteEntity : BaseEntity, IAutoUpdate
{
	public Guid Id { get; set; }
	public DateTimeOffset? EventDate { get; set; }
	[StringLength(128, MinimumLength = 3)]
	public string EventName { get; set; } = string.Empty;
	public string? UserId { get; set; }
	public OrderEntity Order { get; set; }
}