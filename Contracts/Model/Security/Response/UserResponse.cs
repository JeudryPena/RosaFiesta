namespace Contracts.Model.Security.Response;

public class UserResponse : ByBaseResponse
{
	public Guid Id { get; set; }
	public string UserName { get; set; }
	public string Email { get; set; }
	public DateOnly BirthDate { get; set; }
	public bool PromotionalMails { get; set; }
	public IEnumerable<UserRoleResponse> UserRoles { get; set; }
}
