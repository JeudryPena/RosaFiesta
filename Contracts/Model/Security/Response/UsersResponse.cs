namespace Contracts.Model.Security.Response;

public class UsersResponse : BaseResponse
{
	public Guid Id { get; set; }

	public string FullName { get; set; } = string.Empty;

	public string Email { get; set; } = string.Empty;

	public string UserName { get; set; } = string.Empty;

	public int Age => DateTime.UtcNow.Year - BirthDate.Year;
	public DateOnly BirthDate { get; set; }

	public string PhoneNumber { get; set; } = string.Empty;

	public bool TwoFactorEnabled { get; set; }

	public bool PhoneNumberConfirmed { get; set; }

	public bool EmailConfirmed { get; set; }

	public bool LockoutEnabled { get; set; }

	public int AccessFailedCount { get; set; }

	public DateTimeOffset? LockoutEnd { get; set; }

	public string? PasswordHash { get; set; }

	public bool PromotionalMails { get; set; }
	public IEnumerable<UserRoleResponse> UserRoles { get; set; }
}
