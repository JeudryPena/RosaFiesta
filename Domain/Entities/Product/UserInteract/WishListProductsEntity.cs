namespace Domain.Entities.Product.UserInteract;

public class WishListProductsEntity : ISoftDelete
{
	public Guid WishListId { get; set; }
	public Guid OptionId { get; set; }
	public OptionEntity Option { get; set; }
	public bool IsDeleted { get; set; }
}