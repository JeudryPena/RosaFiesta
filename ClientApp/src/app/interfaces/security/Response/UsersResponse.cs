namespace Contracts.Model.Security.Response;

public class UsersResponse : BaseResponse
{
	public Guid Id { get; set; }
	public string UserName { get; set; }
	public string FullName { get; set; }
	public string Email { get; set; }
	public DateOnly BirthDate { get; set; }
	public string PhoneNumber { get; set; }
	public bool EmailConfirmed { get; set; }
	public bool LockoutEnabled { get; set; }
	public int AccessFailedCount { get; set; }
	public DateTimeOffset? LockoutEnd { get; set; }
	public bool PromotionalMails { get; set; }
	public IEnumerable<UserRoleResponse> UserRoles { get; set; }
}
