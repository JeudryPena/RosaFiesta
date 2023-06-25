using System.ComponentModel.DataAnnotations;

using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;

namespace Domain.Entities.Product;

public class DiscountEntity : ByBaseEntity, IAutoBy
{
	[StringLength(25, MinimumLength = 3)]
	public string Code { get; set; }
	[StringLength(50, MinimumLength = 3)]
	public string Name { get; set; }
	public DiscountType Type { get; set; }
	[Range(1, 10000)]
	public double Value { get; set; }
	[Range(1, 5000)]
	public int MaxTimesApply { get; set; }
	public DateTimeOffset Start { get; set; }
	public DateTimeOffset End { get; set; }
	[StringLength(500, MinimumLength = 5)]
	public string? Description { get; set; }
	public ICollection<ProductsDiscountsEntity>? ProductsDiscounts { get; set; }
	public ICollection<AppliedDiscountEntity>? AppliedDiscounts { get; set; }
}