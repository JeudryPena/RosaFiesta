namespace Contracts.Model.Product.UserInteract.Response;

public sealed class PurchaseOrderOptionResponse
{
    public Guid DetailId { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public double Taxes { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsService { get; set; }
    public double Discounted { get; set; }
    public bool? IsReturned { get; set; }
}