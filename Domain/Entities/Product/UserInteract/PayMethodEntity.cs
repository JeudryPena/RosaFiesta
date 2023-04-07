using Domain.Entities.Product.Helpers;
using Domain.Entities.Security;

namespace Domain.Entities.Product.UserInteract;

public class PayMethodEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } 
    public string Description { get; set; }
    public PayMethodType PayMethodType { get; set; }
    public string UserId { get; set; }
    public UserEntity? User { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
}