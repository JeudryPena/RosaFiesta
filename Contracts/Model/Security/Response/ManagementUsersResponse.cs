namespace Contracts.Model.Security.Response;
public class ManagementUsersResponse : ByBaseResponse
{
	public Guid Id { get; set; }
	public string UserName { get; set; }
	public string FullName { get; set; }
	public string Email { get; set; }
	public DateOnly BirthDate { get; set; }
	public bool EmailConfirmed { get; set; }
	public DateTimeOffset? LockoutEnd { get; set; }
	public IEnumerable<UserRoleResponse> UserRoles { get; set; }
}
