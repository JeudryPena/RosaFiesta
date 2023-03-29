using Contracts.Model.Product.UserInteract.Response;

namespace Contracts.Model.Product.Response;

public class OptionResponse
{
    public int Id { get; set; }
    public string Tittle { get; set; }
    public string? Description { get; set; }
    public int Price { get; set; }
    public int QuantityAvaliable { get; set; }
    public string Stock => StockCalculate().ToString();
    public string? Brand { get; set; } 
    public string? Color { get; set; }
    public float? Size { get; set; }
    public float Weight { get; set; }
    public int? GenderFor { get; set; } 
    public int? Material { get; set; }
    public int Condition { get; set; }

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