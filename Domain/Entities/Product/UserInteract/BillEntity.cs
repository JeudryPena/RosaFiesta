using Domain.Entities.Security;

namespace Domain.Entities.Product.UserInteract;

public class BillEntity
{
    public int NumFactura { get; set; }
    public double TotalPrice { get; set; }
    public string? UserId { get; set; }
    public UserEntity? User { get; set; }
    public Guid PayMethodId { get; set; }
    public PayMethodEntity? PayMethod { get; set; }
    public DateTimeOffset PaymentDate { get; set; } = DateTimeOffset.Now;
    public double AmmountPaid { get; set; }
}