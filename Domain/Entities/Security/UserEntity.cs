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
    public string? CreatedBy { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTimeOffset BirthDate { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? RefreshToken { get; set; }
    public bool PromotionalMails { get; set; } 
    public DateTimeOffset? RefreshTokenExpiryTime { get; set; }
    public string Avatar { get; set; } = string.Empty;
    public CartEntity Cart { get; set; }
    public ICollection<ReviewEntity>? Reviews { get; set; } 
    public ICollection<WishListEntity>? WishLists { get; set; }
    public ICollection<OrderEntity>? Orders { get; set; }
    public ICollection<AppliedDiscountEntity>? AppliedDiscounts { get; set; }
}
