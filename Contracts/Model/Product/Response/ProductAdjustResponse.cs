namespace Contracts.Model.Product.Response;

public class ProductAdjustResponse
{
    public string Code { get; set; }
    public string Stock { get; set; } 
    public int? QuantityAvaliable { get; set; }
}