using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;

namespace Domain.Entities.Product;

public class DiscountEntity: BaseEntity
{
    public string DiscountCode { get; set; } = string.Empty;
    public string DiscountName { get; set; } = string.Empty;
    public DiscountType DiscountType { get; set; } 
    public double Discount { get; set; }
    public DateTimeOffset DiscountStartDate { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset DiscountEndDate { get; set; } = DateTimeOffset.Now;
    public string? DiscountDescription { get; set; }
    public string? DiscountImage { get; set; }
    public string? DiscountCodeImage { get; set; }
    public ICollection<ProductEntity>? DiscountProducts { get; set; } 
    public ICollection<PurchaseDetailEntity>? DiscountPurchases { get; set; } 
}