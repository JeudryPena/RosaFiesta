using System.ComponentModel.DataAnnotations;

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
    [Range(0.01, 9999.99)]
    public double ShippingCost { get; set; }
    [Range(0.01, 9999.99)]
    public double TaxesCost { get; set; }
    [StringLength(35, MinimumLength = 3)]
    public VoucherType VoucherType { get; set; }
    public int VoucherNumber { get; set; }
    [StringLength(10, MinimumLength = 3)]
    public string VoucherSeries { get; set; }
}