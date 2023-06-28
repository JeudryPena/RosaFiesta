using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Security;
public class UserRole : IdentityUserRole<string>
{
	public RoleEntity? Role { get; set; }
}
