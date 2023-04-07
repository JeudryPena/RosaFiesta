namespace Contracts.Model.Product.UserInteract.Response;

public class OptionDetailResponse
{
    public int PurchaseNumber { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public int? AppliedId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public int OptionId { get; set; }
}