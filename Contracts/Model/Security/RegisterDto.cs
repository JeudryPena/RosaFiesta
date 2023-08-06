using System.ComponentModel.DataAnnotations;

namespace Contracts.Model.Security;

public class RegisterDto
{
	public string UserName { get; set; }
	public bool PromotionalMails { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }

	[Compare(nameof(Password))]
	public string ConfirmPassword { get; set; }
	public DateOnly BirthDate { get; set; }
}
