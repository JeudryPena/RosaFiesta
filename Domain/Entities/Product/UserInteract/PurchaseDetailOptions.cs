using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Product.UserInteract;

public class PurchaseDetailOptions : BaseEntity, IAutoUpdate
{
	public Guid DetailId { get; set; }
	public PurchaseDetailEntity Detail { get; set; }
	public int Quantity { get; set; }
	public double UnitPrice { get; set; }
	public double? Taxes { get; set; }
	[StringLength(100, MinimumLength = 3)]
	public string Title { get; set; } = string.Empty;
	public bool IsService { get; set; }
	public double? Discounted { get; set; }
	public Guid? AppliedId { get; set; }
	public DiscountEntity? Discount { get; set; }
	public Guid OptionId { get; set; }
	public OptionEntity Option { get; set; }
	public bool? IsReturned { get; set; }
}