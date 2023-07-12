namespace Contracts.Model.Product.Response;

public class OptionPreviewResponse : BaseResponse
{
	public Guid Id { get; set; }
	public double Price { get; set; }
	public double? OfferPrice => Discount == null ? null : Price - (Price * Discount.Value / 100);
	public float? DiscountSave { get; set; }
	public ICollection<MultipleImagesResponse>? Images { get; set; }
	public string Stock => StockCalculate().ToString();
	public int QuantityAvailable { get; set; }
	public string Condition { get; set; }
	public float? AverageRating => Reviews == null || Reviews.Count == 0 ? null : Reviews.Average(r => r.Rating);
	public int? TotalReviews => Reviews == null || Reviews.Count == 0 ? null : Reviews.Count;
	public ICollection<ReviewPreviewResponse>? Reviews { get; set; }
	public DiscountPreviewResponse? Discount { get; set; }

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