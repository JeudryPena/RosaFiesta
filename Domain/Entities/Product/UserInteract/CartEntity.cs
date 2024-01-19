namespace Domain.Entities.Product.UserInteract;

public class CartEntity : ISoftDelete
{
	public Guid Id { get; set; }
	public string UserId { get; set; }
	public IList<PurchaseDetailEntity>? Details { get; set; }
	public bool IsDeleted { get; set; }
}