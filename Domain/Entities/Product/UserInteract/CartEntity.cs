using System.Collections;
using Domain.Entities.Security;

namespace Domain.Entities.Product.UserInteract;

public class CartEntity
{
    public int CartId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public ICollection<PurchaseDetailEntity>? Details { get; set; }
}