namespace Domain.Entities.Product.UserInteract;

public class PurchaseDetailOptions : BaseEntity, IAutoUpdate
{
	public Guid DetailId { get; set; }
	public int Quantity { get; set; }
	public double UnitPrice { get; set; }
	public Guid? AppliedId { get; set; }
	public DiscountEntity? Discount { get; set; }
	public Guid OptionId { get; set; }
	public bool? IsReturned { get; set; }
}