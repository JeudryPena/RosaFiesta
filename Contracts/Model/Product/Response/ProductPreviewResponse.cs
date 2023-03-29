﻿namespace Contracts.Model.Product.Response;

public class ProductPreviewResponse
{
    public string Code { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public double OfferPrice { get; set; }
    public float DiscountSave { get; set; }
    public string? Image { get; set; } 
    public string Stock => StockCalculate().ToString();
    public int QuantityAvaliable { get; set; }
    public string Condition { get; set; }
    public float? AverageRating => Reviews == null || Reviews.Count == 0 ? null : Reviews.Average(r => r.ReviewRating);
    public int? TotalReviews => Reviews == null || Reviews.Count == 0 ? null : Reviews.Count;
    public ICollection<ReviewPreviewResponse>? Reviews { get; set; }
    
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