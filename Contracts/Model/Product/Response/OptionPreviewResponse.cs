namespace Contracts.Model.Product.Response;

public class OptionPreviewResponse
{
    public int Id { get; set; }
    public double Price { get; set; }
    public string? Image { get; set; } 
    public string Stock => StockCalculate().ToString();
    public int QuantityAvaliable { get; set; }
    public float? AverageRating => Reviews == null || Reviews.Count == 0 ? null : Reviews.Average(r => r.ReviewRating);
    public int? TotalReviews => Reviews == null || Reviews.Count == 0 ? null : Reviews.Count;
    public ICollection<ReviewPreviewResponse>? Reviews { get; set; }
    public DiscountPreviewResponse? Discount { get; set; }
    private StockStatusType StockCalculate()
    {
        if (QuantityAvaliable == 0)
            return StockStatusType.OutOfStock;
        if (QuantityAvaliable > 0 && QuantityAvaliable < 10)
            return StockStatusType.LowStock;
        if (QuantityAvaliable >= 10)
            return StockStatusType.InStock;
        return StockStatusType.InStock;
    }
}