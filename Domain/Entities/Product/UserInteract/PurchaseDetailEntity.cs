namespace Domain.Entities.Product.UserInteract;

public class PurchaseDetailEntity : BaseEntity, IAutoUpdate
{
	public int PurchaseNumber { get; set; }
	public Guid ProductId { get; set; }
	public int? OrderId { get; set; }
	public ICollection<PurchaseDetailOptions> PurchaseOptions { get; set; }
	public int? CartId { get; set; }
}