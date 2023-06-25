using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Product.UserInteract;

public class WishListEntity : BaseEntity, IAutoUpdate
{
	public int Id { get; set; }
	[StringLength(50, MinimumLength = 3)]
	public string? Title { get; set; }
	[StringLength(250, MinimumLength = 3)]
	public string? Description { get; set; }
	public ICollection<WishListProductsEntity>? ProductsWish { get; set; }
	public string UserId { get; set; }
}