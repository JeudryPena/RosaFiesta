namespace Contracts.Model.Product.Response;
public class OptionsResponse
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public string? Description { get; set; }
	public double Price { get; set; }
	public string? Color { get; set; }
	public bool? IsMale { get; set; }
	public int Condition { get; set; }
	public string Stock => StockCalculate().ToString();
	public int QuantityAvailable { get; set; }
	public IEnumerable<MultipleImagesResponse> Images { get; set; }

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
