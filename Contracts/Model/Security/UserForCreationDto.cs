using System.ComponentModel.DataAnnotations;

namespace Contracts.Model.Security;

public class UserForCreationDto
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = string.Empty;
    public DateTimeOffset BirthDate { get; set; } = DateTimeOffset.Now;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public Boolean PromotionalMails { get; set; } = false;
}