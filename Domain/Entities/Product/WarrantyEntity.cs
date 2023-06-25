using System.ComponentModel.DataAnnotations;

using Domain.Entities.Product.Helpers;

namespace Domain.Entities.Product;

public class WarrantyEntity : ByBaseEntity, IAutoBy
{
	public Guid Id { get; set; }
	[StringLength(100, MinimumLength = 5)]
	public string Name { get; set; }
	[StringLength(50, MinimumLength = 3)]
	public WarrantyType Type { get; set; }
	[StringLength(50, MinimumLength = 3)]
	public WarrantyStatusType? Status { get; set; }
	[StringLength(100, MinimumLength = 5)]
	public string Period { get; set; }
	[StringLength(1000, MinimumLength = 5)]
	public string Description { get; set; }
	[StringLength(500, MinimumLength = 10)]
	public string Conditions { get; set; }
}