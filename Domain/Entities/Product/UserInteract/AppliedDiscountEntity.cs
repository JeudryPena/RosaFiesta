using Domain.Entities.Security;

namespace Domain.Entities.Product.UserInteract;

public class AppliedDiscountEntity
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public UserEntity User { get; set; }
    public string DiscountCode { get; set; }
    public DiscountEntity Discount { get; set; }
    public int PurchaseNumber { get; set; }
    public PurchaseDetailEntity PurchaseDetail { get; set; }
    public DateTimeOffset AppliedDate { get; set; }
}