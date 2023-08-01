using Contracts.Model.Product.UserInteract.Response;

namespace Contracts.Model.Product.Response;
public class OptionDetailResponse
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public string? Description { get; set; }
	public ICollection<MultipleImagesResponse>? Images { get; set; }
	public MultipleImagesResponse Image { get; set; }
	public Guid ImageId { get; set; }
	public double Price { get; set; }
	public string? Color { get; set; }
	public string GenderFor { get; set; }
	public string Stock => StockCalculate().ToString();
	public int QuantityAvailable { get; set; }
	public DiscountPreviewResponse? Discount { get; set; }
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
