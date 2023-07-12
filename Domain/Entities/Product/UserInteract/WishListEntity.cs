namespace Domain.Entities.Product.UserInteract;

public class WishListEntity : BaseEntity, IAutoUpdate
{
	public Guid Id { get; set; }
	public ICollection<WishListProductsEntity>? ProductsWish { get; set; }
	public string UserId { get; set; }
}