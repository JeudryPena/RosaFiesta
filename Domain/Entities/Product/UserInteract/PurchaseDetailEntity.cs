namespace Domain.Entities.Product.UserInteract;

public class PurchaseDetailEntity : BaseEntity
{
	public int PurchaseNumber { get; set; }
	public string ProductId { get; set; }
	public int? OrderId { get; set; }
	public ICollection<PurchaseDetailOptions> PurchaseOptions { get; set; }
	public int? CartId { get; set; }
}