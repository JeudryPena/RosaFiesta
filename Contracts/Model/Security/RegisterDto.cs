using System.ComponentModel.DataAnnotations;

namespace Contracts.Model.Security;

public class RegisterDto
{
	public string UserName { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;

	[Compare(nameof(Password))]
	public string ConfirmPassword { get; set; } = string.Empty;
	public DateOnly BirthDate { get; set; }
}
