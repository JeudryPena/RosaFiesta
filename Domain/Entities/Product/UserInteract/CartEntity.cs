using System.Collections;
using Domain.Entities.Security;

namespace Domain.Entities.Product.UserInteract;

public class CartEntity
{
    public int CartId { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
    public string UserId { get; set; } = string.Empty;
    public UserEntity UserEntity { get; set; } 
    public ICollection<PurchaseDetailEntity>? Details { get; set; }
}