using Domain.Entities.Product;
using Domain.Entities.Product.UserInteract;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Security;

public class UserEntity : IdentityUser
{
    public string FullName { get; set; } = String.Empty;
    public int Age { get; set; }
    public CivilType CivilStatus { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset BirthDate { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? RefreshToken { get; set; }
    public DateTimeOffset? RefreshTokenExpiryTime { get; set; }
    public string Avatar { get; set; } = string.Empty;
    public ICollection<CartEntity>? CartProducts { get; set; } 
    public ICollection<ReviewEntity>? Reviews { get; set; } 
    public ICollection<WishListEntity>? WishLists { get; set; }
    public ICollection<BillEntity>? Bills { get; set; }
}
