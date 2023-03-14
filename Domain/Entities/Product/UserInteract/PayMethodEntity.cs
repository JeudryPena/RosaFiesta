namespace Domain.Entities.Product.UserInteract;

public class PayMethodEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<OrderEntity> Bills { get; set; } 
    
    public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
    
    public DateTimeOffset? UpdatedDate { get; set; }
}