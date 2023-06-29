using Contracts.Model.Product.UserInteract.Response;

namespace Contracts.Model.Product.Response;
public class OptionDetailResponse
{
	public int Id { get; set; }
	public string? Description { get; set; }
	public ICollection<MultipleImagesResponse>? Images { get; set; }
	public double Price { get; set; }
	public string? Color { get; set; }
	public float? Size { get; set; }
	public float Weight { get; set; }
	public string? GenderFor { get; set; }
	public string? Material { get; set; }
	public string Type { get; set; }
	public string Stock => StockCalculate().ToString();
	public int QuantityAvailable { get; set; }
	public double? OfferPrice => Discount == null ? null : Discount.Type == 1 ? Price - Price * Discount.Value / 100 : Price - Discount.Value;
	public float? DiscountSave { get; set; }
	public DiscountPreviewResponse? Discount { get; set; }
	public float AverageRating => Reviews.Average(x => x.Rating);
	public int TotalReviews => Reviews.Count;
	public int TotalSales { get; set; }
	public ICollection<ReviewResponse>? Reviews { get; set; }
	public string Condition { get; set; }
	private StockStatusType StockCalculate()
	{
		if (QuantityAvailable == 0)
			return StockStatusType.OutOfStock;
		if (QuantityAvailable > 0 && QuantityAvailable < 10)
			return StockStatusType.LowStock;
		if (QuantityAvailable >= 10)
			return StockStatusType.InStock;
		return StockStatusType.InStock;
	}
}
