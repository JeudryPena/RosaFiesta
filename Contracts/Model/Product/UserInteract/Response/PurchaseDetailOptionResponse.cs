namespace Contracts.Model.Product.UserInteract.Response;

public class PurchaseDetailOptionResponse
{
    public string Image { get; set; }
    public int Quantity { get; set; }
    public int OptionId { get; set; }
    public double UnitPrice { get; set; }
    public int? AppliedId { get; set; }
    public double TotalPrice => UnitPrice * Quantity;
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public bool IsReturned { get; set; }
}