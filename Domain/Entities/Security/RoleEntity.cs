using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Security;
public class RoleEntity : IdentityRole<string>, ISoftDelete
{
	public virtual ICollection<UserRole>? UserRoles { get; set; }
	public bool IsDeleted { get; set; }
}
