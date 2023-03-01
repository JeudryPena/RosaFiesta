using Domain.Entities.Security;

namespace Domain.Entities.Product;

public class CartEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Quantity { get; set; } 
    public double TotalPrice { get; set; }
    public Guid? ProductId { get; set; }
    public ProductEntity? ProductEntity { get; set; } = new();
    public Guid UserId { get; set; } 
    public UserEntity UserEntity { get; set; } = new();
    public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset? UpdatedDate { get; set; }
}