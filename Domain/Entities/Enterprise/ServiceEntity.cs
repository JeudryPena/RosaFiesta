using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Enterprise;

public class ServiceEntity : ByBaseEntity, IAutoBy
{
	public Guid Id { get; set; }
	[StringLength(100, MinimumLength = 2)]
	public string Name { get; set; }
	[StringLength(700, MinimumLength = 3)]
	public string Description { get; set; }
	[Range(0, 99999)]
	public decimal Price { get; set; }
	[StringLength(1000, MinimumLength = 10)]
	public string Image { get; set; }
	public ICollection<QuoteItemEntity> QuoteItems { get; set; }
	[Range(0, 1000)]
	public int QuantityAvailable { get; set; }
	[Range(0, 1000)]
	public int Quantity { get; set; }
}