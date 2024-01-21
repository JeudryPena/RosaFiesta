using System.ComponentModel.DataAnnotations;

namespace Contracts.Model.Security;

public class changePasswordDto
{
    public string OldPassword { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
    [Compare("NewPassword", ErrorMessage = "Password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}