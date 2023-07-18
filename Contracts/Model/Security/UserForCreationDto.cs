using System.ComponentModel.DataAnnotations;

namespace Contracts.Model.Security;

public class UserForCreationDto
{
	public string UserName { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
	[Compare(nameof(Password))]
	public string ConfirmPassword { get; set; }
	public DateOnly BirthDate { get; set; }
	public string Name { get; set; }
	public string LastName { get; set; }
	public IEnumerable<UserRoleDto> RolesId { get; set; }
	public bool PromotionalMails { get; set; }
}