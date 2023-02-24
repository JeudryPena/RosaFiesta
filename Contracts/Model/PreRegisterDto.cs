namespace Contracts.Model;

public class PreRegisterDto
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    
    public string ConfirmPassword { get; set; } = string.Empty;
    
    public string PhoneNumber { get; set; } = string.Empty;
}
