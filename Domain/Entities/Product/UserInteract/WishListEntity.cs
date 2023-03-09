using Domain.Entities.Security;

namespace Domain.Entities.Product.UserInteract;

public class WishListEntity
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset? UpdatedDate { get; set; }
    public ICollection<ProductEntity>? Products { get; set; }
    public string UserId { get; set; } = string.Empty;
    public UserEntity UserEntity { get; set; } 
}