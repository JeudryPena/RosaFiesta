namespace Contracts.Model.Product.Response;

public class PurchaseDetailResponse: BaseResponse
{
    public int PurchaseNumber { get; set; }
    public Guid BillId { get; set; }
    public string? ProductId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public string PurchaseStatus { get; set; } 
    public string? DiscountId { get; set; } 
    public double PurchaseTotal { get; set; }
}