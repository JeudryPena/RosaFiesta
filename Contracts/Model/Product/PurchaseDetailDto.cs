namespace Contracts.Model.Product;

public class PurchaseDetailDto
{
    public int PurchaseNumber { get; set; }
    public Guid BillId { get; set; }
    public int ProductId { get; set; }
    public int PurchaseId { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public string? DiscountApplied { get; set; }
}