namespace Contracts.Model.Product.UserInteract.Response;

public class PurchaseDetailResponse
{
    public int PurchaseNumber { get; set; }
    public string? ProductId { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public string? DiscountId { get; set; } 
    public double TotalPrice => UnitPrice * Quantity;
    public int CartId { get; set; }
}