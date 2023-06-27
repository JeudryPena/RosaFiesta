namespace Contracts.Model.Product.Response;
public class OptionsResponse
{
	public int Id { get; set; }	
	public string Title { get; set; }
	public double Price { get; set; }
	public string? Image { get; set; }
	public string Stock => StockCalculate().ToString();
	public int QuantityAvaliable { get; set; }
	public string Condition { get; set; }
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
