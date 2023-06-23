using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Product.UserInteract;

public class AppliedDiscountEntity : BaseEntity
{
	public int Id { get; set; }
	public string UserId { get; set; }
	[StringLength(25, MinimumLength = 5)]
	public string Code { get; set; }
	public PurchaseDetailOptions PurchaseOption { get; set; }
}