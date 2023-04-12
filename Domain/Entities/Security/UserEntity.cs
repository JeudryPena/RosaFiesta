using System.Net.Sockets;
using System.Runtime.CompilerServices;
using Domain.Entities.Enterprise;
using Domain.Entities.Product;
using Domain.Entities.Product.UserInteract;
using Domain.Entities.Security.Helper;
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
    public string? RefreshToken { get; set; }
    public bool PromotionalMails { get; set; } 
    public DateTimeOffset? RefreshTokenExpiryTime { get; set; }
    public string? Avatar { get; set; }
    public bool hasAvatar { get; set; }
    public CartEntity Cart { get; set; }
    public ICollection<ReviewEntity>? Reviews { get; set; } 
    public ICollection<WishListEntity>? WishLists { get; set; }
    public ICollection<OrderEntity>? Orders { get; set; }
    public ICollection<AppliedDiscountEntity>? AppliedDiscounts { get; set; }
    public ICollection<AddressEntity>? Addresses { get; set; }
    public AddressEntity? DefaultAddress { get; set; }
    public Guid? DefaultAddressId { get; set; }
    public ICollection<PayMethodEntity>? PayMethods { get; set; }
    public PayMethodEntity? PayMethod { get; set; }
    public Guid? DefaultPayMethodId { get; set; }
    public ICollection<QuoteEntity>? Quotes { get; set; }
}
