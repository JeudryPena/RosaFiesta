namespace Contracts.Model.Product.Response;

public class OptionAdjustResponse
{
    public int Id { get; set; }
    public string Stock => StockCalculate().ToString();
    public int? QuantityAvailable { get; set; }
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