namespace Contracts.Model.Product.Response;

public class CartProductsResponse
{
    public string? ProductId { get; set; }
    public int CartId { get; set; }
    public int Quantity { get; set; }
    public double PricePerUnit { get; set; }
}