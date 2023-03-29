using System.ComponentModel.DataAnnotations;

namespace Contracts.Model.Security;

public class LogingDto
{
    /// <summary>
    /// Represent the user name to login to the system.
    /// </summary>
    [Required(ErrorMessage = "User Title is required")]
    [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
    [EmailAddress]
    public string Username { get; set; }
    
    /// <summary>
    /// Represent the password to login to the system.
    /// </summary>
    [Required(ErrorMessage = "Password is required")]  
    [DataType(DataType.Password)]
    public string Password { get; set; }  
    
    public bool RememberMe { get; set; }
}
