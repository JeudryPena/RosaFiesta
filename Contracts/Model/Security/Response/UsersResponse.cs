using Contracts.Model.Product.Response;
using Contracts.Model.Product.UserInteract.Response;

namespace Contracts.Model.Security.Response;

public class UsersResponse : BaseResponse
{
	public Guid Id { get; set; }

	public string FullName { get; set; } = string.Empty;

	public string Email { get; set; } = string.Empty;

	public string UserName { get; set; } = string.Empty;

	public int Age { get; set; }
	public DateTimeOffset BirthDate { get; set; }

	public string PhoneNumber { get; set; } = string.Empty;

	public bool TwoFactorEnabled { get; set; }

	public bool PhoneNumberConfirmed { get; set; }

	public bool EmailConfirmed { get; set; }

	public bool LockoutEnabled { get; set; }

	public int AccessFailedCount { get; set; }

	public DateTimeOffset? LockoutEnd { get; set; }

	public string? PasswordHash { get; set; }

	public bool PromotionalMails { get; set; }

	public ICollection<OrderResponse>? Orders { get; set; }

	public ICollection<ReviewResponse>? Reviews { get; set; }

	public ICollection<WishListResponse>? WishLists { get; set; }

	public ICollection<AppliedDiscountResponse>? AppliedDiscounts { get; set; }
}
