using System.ComponentModel.DataAnnotations;
using Domain.Entities.Security;

namespace Domain.Entities.Product;

public class WishListEntity
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public ICollection<ProductEntity>? Products { get; set; }
    public Guid UserId { get; set; } 
    public UserEntity UserEntity { get; set; } = new();
    public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset? UpdatedDate { get; set; }
}