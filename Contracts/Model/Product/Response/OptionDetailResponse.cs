using Contracts.Model.Product.UserInteract.Response;

namespace Contracts.Model.Product.Response;
public class OptionDetailResponse
{
	public Guid Id { get; set; }
	public string? Description { get; set; }
	public ICollection<MultipleImagesResponse>? Images { get; set; }
	public double Price { get; set; }
	public string? Color { get; set; }
	public bool? IsMale { get; set; }
	public string Type { get; set; }
	public string Stock => StockCalculate().ToString();
	public int QuantityAvailable { get; set; }
	public double? OfferPrice => Discount == null ? null : Price - (Price * Discount.Value / 100);
	public DiscountPreviewResponse? Discount { get; set; }
	public float AverageRating => Reviews.Average(x => x.Rating);
	public int TotalReviews => Reviews.Count;
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
