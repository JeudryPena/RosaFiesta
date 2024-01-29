namespace Domain.Entities.Product.UserInteract;

public class PurchaseDetailEntity : BaseEntity, IAutoUpdate
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public Guid ProductId { get; set; }
	public Guid? OrderId { get; set; }
	public OrderEntity? Order { get; set; }
	public Guid? WarrantyId { get; set; }
	public WarrantyEntity? Warranty { get; set; }
	public IList<PurchaseDetailOptions> PurchaseOptions { get; set; } = new List<PurchaseDetailOptions>();
	public Guid? CartId { get; set; }
	public CartEntity? Cart { get; set; }
}