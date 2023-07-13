using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Security;
public class UserRole : IdentityUserRole<string>, ISoftDelete
{
	public bool IsDeleted { get; set; }
	public virtual UserEntity? User { get; set; }
	public virtual RoleEntity? Role { get; set; }
}
