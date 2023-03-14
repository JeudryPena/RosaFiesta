namespace Domain.Entities.Product.UserInteract;

public class CartProductsEntity
{
    public int CartId { get; set; }
    public CartEntity Cart { get; set; }
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public int Quantity { get; set; }
}