namespace Contracts.Model.Product.Response;
public class OptionResponse
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string? Description { get; set; }
	public double Price { get; set; }
	public string? Color { get; set; }
	public float? Size { get; set; }
	public float Weight { get; set; }
	public string? GenderFor { get; set; }
	public string? Material { get; set; }
	public string Condition { get; set; }
	public string? Images { get; set; } = string.Empty;
	public string Stock => StockCalculate().ToString();
	public int QuantityAvailable { get; set; }

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
