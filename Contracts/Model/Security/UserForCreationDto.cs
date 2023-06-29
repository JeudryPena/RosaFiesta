using System.ComponentModel.DataAnnotations;

namespace Contracts.Model.Security;

public class UserForCreationDto
{
	public string UserName { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
	[Compare(nameof(Password))]
	public string ConfirmPassword { get; set; } = string.Empty;
	public DateOnly BirthDate { get; set; }
	public string PhoneNumber { get; set; } = string.Empty;
	public string Name { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;
	public IEnumerable<string> RoleId { get; set; }
	public bool PromotionalMails { get; set; } = false;
}