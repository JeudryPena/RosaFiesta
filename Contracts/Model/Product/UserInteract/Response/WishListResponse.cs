using Contracts.Model.Product.Response;

namespace Contracts.Model.Product.UserInteract.Response;

public class WishListResponse 
{
	public Guid Id { get; set; }
	public ICollection<WishListProductsResponse>? ProductsWish { get; set; }
}