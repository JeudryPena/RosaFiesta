using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Security;
public class RoleEntity : IdentityRole<string>
{
	public virtual ICollection<UserRole>? UserRoles { get; set; }
}
