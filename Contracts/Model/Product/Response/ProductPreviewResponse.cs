namespace Contracts.Model.Product.Response;

public class ProductPreviewResponse
{
    public string Code { get; set; }
    public string Tittle { get; set; }
    public double Price { get; set; }
    public double OfferPrice { get; set; }
    public float DiscountSave { get; set; }
    public double ShippingCost { get; set; }
    public float AverageRating { get; set; }
    public int TotalReviews { get; set; }
    public string? Image { get; set; } 
    public string Stock { get; set; } 
    public int QuantityAvaliable { get; set; }
    public string Condition { get; set; }
}