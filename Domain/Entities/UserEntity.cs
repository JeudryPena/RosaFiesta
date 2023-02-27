using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class UserEntity : IdentityUser
{
    public string FullName { get; set; } = String.Empty; 
    
    public int Age { get; set; }
    
    public CivilType CivilStatus { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    
    public DateTimeOffset? UpdatedAt { get; set; }
    
    public DateTimeOffset BirthDate { get; set; }
    
    public string? Address { get; set; }
    
    public string? City { get; set; }
    
    public string? State { get; set; }

    public bool IsLockedOut { get; set; }
}
