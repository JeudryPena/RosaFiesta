namespace Contracts.Model.Product.Response;

public class ProductCartResponse
{
    public string Code { get; set; }
    public string Tittle { get; set; }
    public double Price { get; set; }
    public double OfferPrice { get; set; }
    public float DiscountSave { get; set; }
    public string? Image { get; set; }
    public int QuantityAvaliable { get; set; }
    public string Stock { get; set; }
}