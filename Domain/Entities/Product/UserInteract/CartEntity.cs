namespace Domain.Entities.Product.UserInteract;

public class CartEntity : ISoftDelete
{
	public Guid CartId { get; set; }
	public string UserId { get; set; }
	public ICollection<PurchaseDetailEntity>? Details { get; set; }
	public bool IsDeleted { get; set; }
}