using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Enterprise;

public class QuoteItemEntity : BaseEntity
{
	public int Id { get; set; }
	[StringLength(250, MinimumLength = 1)]
	public int Quantity { get; set; }
	[StringLength(36, MinimumLength = 32)]
	public int QuoteId { get; set; }
	[Range(0, 9999999)]
	public decimal Price { get; set; }
	public Guid ServiceId { get; set; }
}