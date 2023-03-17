using Domain.Entities.Security;

namespace Domain.Entities.Product.UserInteract;

public class AppliedDiscountEntity
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public UserEntity User { get; set; }
    public string DiscountCode { get; set; }
    public DiscountEntity Discount { get; set; }
    public int TimesApplied { get; set; }
    public DateTimeOffset AppliedDate { get; set; }
    public int OrderId { get; set; }
    public OrderEntity Order { get; set; }
}