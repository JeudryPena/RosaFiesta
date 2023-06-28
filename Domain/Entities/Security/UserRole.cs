using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Security;
public class UserRole : IdentityUserRole<string>
{
	public virtual UserEntity? User { get; set; }
	public virtual RoleEntity? Role { get; set; }
}
