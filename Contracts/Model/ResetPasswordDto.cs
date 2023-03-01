using System.ComponentModel.DataAnnotations;

namespace Contracts.Model;

public class ResetPasswordDto
{ 
    public string Password { get; set; } = string.Empty;
    
    [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}