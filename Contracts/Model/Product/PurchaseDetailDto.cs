namespace Contracts.Model.Product;

public class PurchaseDetailDto
{
    public int PurchaseNumber { get; set; }
    public Guid? BillId { get; set; }
    public string ProductId { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public string? DiscountId { get; set; }
    public int CartId { get; set; }
}