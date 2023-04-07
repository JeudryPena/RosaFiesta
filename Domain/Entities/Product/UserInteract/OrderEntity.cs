using Domain.Entities.Product.Helpers;
using Domain.Entities.Security;

namespace Domain.Entities.Product.UserInteract;

public class OrderEntity
{
    public int SKU { get; set; }
    public string? UserId { get; set; }
    public UserEntity? User { get; set; }
    public Guid PayMethodId { get; set; }
    public ICollection<PurchaseDetailEntity>? Details { get; set; }
    public PayMethodEntity? PayMethod { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public Guid AddressId { get; set; }
    public AddressEntity? Address { get; set; }
    public double ShippingCost { get; set; }
    public double TaxesCost { get; set; }
    public VoucherType VoucherType { get; set; }
    public int VoucherNumber { get; set; }
    public string VoucherSeries { get; set; }
    public OrderStatusType OrderStatus { get; set; }
}