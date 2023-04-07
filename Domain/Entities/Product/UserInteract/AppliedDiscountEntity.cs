using Domain.Entities.Security;

namespace Domain.Entities.Product.UserInteract;

public class AppliedDiscountEntity
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string DiscountCode { get; set; }
    public PurchaseDetailOptions PurchaseOption { get; set; }
    public DateTimeOffset AppliedDate { get; set; }
}