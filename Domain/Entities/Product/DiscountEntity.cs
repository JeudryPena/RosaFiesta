using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;

namespace Domain.Entities.Product;

public class DiscountEntity: BaseEntity
{
    public string DiscountCode { get; set; } 
    public string DiscountName { get; set; }
    public DiscountType DiscountType { get; set; }
    public double DiscountValue { get; set; }
    public int MaxTimesApply { get; set; }
    public DateTimeOffset DiscountStartDate { get; set; } 
    public DateTimeOffset DiscountEndDate { get; set; }
    public string? DiscountDescription { get; set; }
    public string? DiscountImage { get; set; }
    public ICollection<ProductsDiscountsEntity>? ProductsDiscounts { get; set; }
    public ICollection<AppliedDiscountEntity>? AppliedDiscounts { get; set; }
}