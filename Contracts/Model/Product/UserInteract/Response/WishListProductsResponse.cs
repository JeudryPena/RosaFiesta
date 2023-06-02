namespace Contracts.Model.Product.UserInteract.Response;

public class WishListProductsResponse
{
    public int WishListId { get; set; }
    public string Title { get; set; }
    public List<ProductsWishListDto> ProductsWish { get; set; }
}