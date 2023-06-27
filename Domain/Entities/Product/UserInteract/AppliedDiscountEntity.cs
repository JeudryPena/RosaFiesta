using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Product.UserInteract;

public class AppliedDiscountEntity : BaseEntity, IAutoUpdate
{
	public int Id { get; set; }
	public string UserId { get; set; }
	[StringLength(25, MinimumLength = 5)]
	public Guid DiscountId { get; set; }
	public PurchaseDetailOptions PurchaseOption { get; set; }
}