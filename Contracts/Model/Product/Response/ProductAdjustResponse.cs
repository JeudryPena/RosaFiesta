namespace Contracts.Model.Product.Response;

public class ProductAdjustResponse
{
    public string Code { get; set; }
    public string Stock => StockCalculate().ToString();
    public int? QuantityAvaliable { get; set; }
     
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