using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Security;
public class RoleEntity : IdentityRole<string>
{
	public ICollection<UserRole>? UserRoles { get; set; }
}
