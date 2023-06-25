namespace Domain.Entities.Product.UserInteract;

public class WishListProductsEntity : ISoftDelete
{
	public int WishListId { get; set; }
	public int OptionId { get; set; }
	public OptionEntity Option { get; set; }
	public bool IsDeleted { get; set; }
}