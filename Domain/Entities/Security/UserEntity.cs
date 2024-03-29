using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Domain.Entities.Enterprise;
using Domain.Entities.Product.UserInteract;

using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Security;

public class UserEntity : IdentityUser, IAutoBy
{
	[NotMapped]
	public override string PhoneNumber { get; set; }
	[NotMapped]
	public override bool PhoneNumberConfirmed { get; set; }
	[Range(16, 150)]
	public DateOnly BirthDate { get; set; }
	public string? RefreshToken { get; set; }
	public bool PromotionalMails { get; set; }
	public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
	public DateTimeOffset? UpdatedAt { get; set; }
	public string? CreatedBy { get; set; }
	public string? UpdatedBy { get; set; }
	public DateTimeOffset? RefreshTokenExpiryTime { get; set; }
	public CartEntity Cart { get; set; }
	public WishListEntity? WishList { get; set; } 
	public Guid? WishListId { get; set; }
	public ICollection<OrderEntity>? Orders { get; set; }
	public ICollection<QuoteEntity>? Quotes { get; set; }
	public bool IsDeleted { get; set; }
	public virtual ICollection<UserRole> UserRoles { get; set; }
}
