namespace Contracts.Model.Product.UserInteract.Response;

public class OrderResponse
{
    public int SKU { get; set; }
    public Guid PayMethodId { get; set; }
    public string UserId { get; set; }
    public DateTimeOffset PaymentDate { get; set; }
    public string ShippingAddress { get; set; }
    public string OrderAddress { get; set; }
    public string OrderPhone { get; set; }
    public string OrderEmail { get; set; }
    public double ShippingCost { get; set; }
    public string VoucherType { get; set; }
    public int VoucherNumber { get; set; }
    public string VoucherSeries { get; set; }
    public string OrderStatus { get; set; }
    public double AmmountPaid => Details.Sum(x => x.UnitPrice * x.Quantity) + ShippingCost;
    public double TaxesCost { get; set; }
    public ICollection<PurchaseDetailResponse> Details { get; set; }
}