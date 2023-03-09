using Domain.Entities.Security;

namespace Domain.Entities.Product.UserInteract;

public class CartEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Quantity { get; set; } 
    public double TotalPrice { get; set; }
    public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset? UpdatedDate { get; set; }
    
    public string? ProductId { get; set; }
    public ProductEntity? ProductEntity { get; set; } 
    public string UserId { get; set; } = string.Empty;
    public UserEntity UserEntity { get; set; } 
}