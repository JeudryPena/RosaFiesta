using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Product.UserInteract;

public class AppliedDiscountEntity
{
    public int Id { get; set; }
    public string UserId { get; set; }
    [StringLength(25, MinimumLength = 5)]
    public string DiscountCode { get; set; }
    public PurchaseDetailOptions PurchaseOption { get; set; }
    public DateTimeOffset AppliedDate { get; set; }
}