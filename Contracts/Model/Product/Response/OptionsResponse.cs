namespace Contracts.Model.Product.Response;
public class OptionsResponse
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string? Description { get; set; }
	public double Price { get; set; }
	public string? Image { get; set; }
	public string Stock => StockCalculate().ToString();
	public int QuantityAvailable { get; set; }
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
