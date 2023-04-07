using Contracts.Model.Security.Response;

namespace Contracts.Model.Product.UserInteract.Response;

public class OrderResponse
{
    public int SKU { get; set; }
    public Guid PayMethodId { get; set; }
    public string UserId { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public double ShippingCost { get; set; }
    public string VoucherType { get; set; }
    public int VoucherNumber { get; set; }
    public string VoucherSeries { get; set; }
    public string OrderStatus { get; set; }
    public double AmmountPaid => Details.Sum(x => x.TotalOptionsPrice);
    public double TaxesCost { get; set; }
    public ICollection<PurchaseDetailResponse> Details { get; set; }
    public Guid AddressId { get; set; }
    public AddressResponse Address { get; set; }
}