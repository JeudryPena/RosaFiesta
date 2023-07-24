namespace Domain.Entities.Product.UserInteract;

public class PurchaseDetailEntity : BaseEntity, IAutoUpdate
{
	public Guid Id { get; set; }
	public Guid ProductId { get; set; }
	public Guid? OrderId { get; set; }
	public ICollection<PurchaseDetailOptions> PurchaseOptions { get; set; }
	public Guid? CartId { get; set; }
	public Guid? QuoteId { get; set; }
}