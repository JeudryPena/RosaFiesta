namespace Contracts.Model.Product.Response;

public class CartResponse
{
    public double TotalPrice { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
    public string? UserId { get; set; }
    public IEnumerable<CartProductsResponse>? CartProducts { get; set; }
}