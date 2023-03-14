namespace Domain.Entities.Product.UserInteract;

public class WishListProductsEntity
{
    public int WishListId { get; set; }
    public WishListEntity WishList { get; set; }
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}