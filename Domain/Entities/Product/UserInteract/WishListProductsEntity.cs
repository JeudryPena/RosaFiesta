namespace Domain.Entities.Product.UserInteract;

public class WishListProductsEntity
{
    public int WishListId { get; set; }
    public WishListEntity WishList { get; set; }
    public string ProductId { get; set; }
    public ProductEntity Product { get; set; }
    public int OptionId { get; set; }
    public OptionEntity Option { get; set; }
}