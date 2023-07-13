using System.ComponentModel.DataAnnotations;

namespace Contracts.Model.Security;

public class ResetPasswordDto
{ 
    public string Password { get; set; }
    
    [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } 
}