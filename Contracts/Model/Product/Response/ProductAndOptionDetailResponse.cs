using Contracts.Model.Product.UserInteract.Response;

namespace Contracts.Model.Product.Response;

public class ProductAndOptionDetailResponse
{
    public string Code { get; set; }
    public string Tittle { get; set; } 
    public string? Description { get; set; }
    public ICollection<MultipleImagesResponse>? Images { get; set; }
    public double Price { get; set; }
    public double? OfferPrice => Discount == null ? null : Discount.DiscountType == 1 ? Price - Price * Discount.DiscountValue / 100 : Price - Discount.DiscountValue;
    public float? DiscountSave { get; set; }
    public string Stock => StockCalculate().ToString(); 
    public int QuantityAvaliable { get; set; }
    public string? Brand { get; set; } 
    public string? Color { get; set; }
    public float? Size { get; set; }
    public float Weight { get; set; }
    public string? GenderFor { get; set; }
    public string? Material { get; set; } 
    public string Type { get; set; } 
    public string Condition { get; set; } 
    public int? CategoryId { get; set; }
    public DateTimeOffset LastReviewDate => Reviews.Max(x => x.ReviewDate);
    public float AverageRating => Reviews.Average(x => x.ReviewRating);
    public int TotalReviews => Reviews.Count;
    public int TotalSales { get; set; }
    public ICollection<ReviewResponse>? Reviews { get; set; }
    public int? TotalOptions => Options.Count;
    public ICollection<OptionPreviewResponse> Options { get; set; }
    public int? OptionId { get; set; }
    
    public Guid WarrantyId { get; set; }
    public DiscountPreviewResponse? Discount { get; set; }
    public string? WarrantyName { get; set; }

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