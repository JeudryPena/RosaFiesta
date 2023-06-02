using System.ComponentModel.DataAnnotations;

using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;

namespace Domain.Entities.Product;

public class DiscountEntity
{
    [StringLength(25, MinimumLength = 5)]
    public string DiscountCode { get; set; }
    [StringLength(50, MinimumLength = 5)]
    public string DiscountName { get; set; }
    [StringLength(25, MinimumLength = 5)]
    public DiscountType DiscountType { get; set; }
    [Range(1, 10000)]
    public double DiscountValue { get; set; }
    [Range(1, 10000)]
    public int MaxTimesApply { get; set; }
    public DateTimeOffset DiscountStartDate { get; set; }
    public DateTimeOffset DiscountEndDate { get; set; }
    [StringLength(500, MinimumLength = 5)]
    public string? DiscountDescription { get; set; }
    public string? DiscountImage { get; set; }
    public ICollection<ProductsDiscountsEntity>? ProductsDiscounts { get; set; }
    public ICollection<AppliedDiscountEntity>? AppliedDiscounts { get; set; }
}