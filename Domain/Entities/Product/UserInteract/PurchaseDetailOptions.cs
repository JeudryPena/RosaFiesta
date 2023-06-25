using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Product.UserInteract;

public class PurchaseDetailOptions : BaseEntity, IAutoUpdate
{
	public int PurchaseNumber { get; set; }
	[Range(0, 1000)]
	public int Quantity { get; set; }
	[Range(0.01, 999999.99)]
	public double UnitPrice { get; set; }
	public int? AppliedId { get; set; }
	public AppliedDiscountEntity? DiscountApplied { get; set; }
	public int OptionId { get; set; }
	public bool? IsReturned { get; set; }
}