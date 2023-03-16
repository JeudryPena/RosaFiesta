using Domain.Entities.Product.Helpers;

namespace Domain.Entities.Product.UserInteract;

public class PayMethodEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } 
    public string Description { get; set; }
    public PayMethodType PayMethodType { get; set; }
    public ICollection<OrderEntity> Orders { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
}