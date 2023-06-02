using Contracts.Model.Product.UserInteract.Response;

namespace Contracts.Model.Product.Response;

public class ProductAndOptionResponse
{
    public string? Code { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public double Price { get; set; }
    public string? Images { get; set; } = string.Empty;
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
    public Guid? WarrantyId { get; set; }
    public Guid? SupplierId { get; set; }
    public int OptionId { get; set; }
    public DateTimeOffset? LastDate => Reviews == null || Reviews.Count == 0 ? null : Reviews.Max(r => r.Date);
    public float? AverageRating => Reviews == null || Reviews.Count == 0 ? null : Reviews.Average(r => r.Rating);
    public int? TotalReviews => Reviews == null || Reviews.Count == 0 ? null : Reviews.Count;
    public ICollection<ReviewResponse>? Reviews { get; set; }
    public int TotalOptions => Options.Count;
    public ICollection<OptionPreviewResponse> Options { get; set; }

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