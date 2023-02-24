using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class UserEntity : IdentityUser
{
    public string Name { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;
    
    public int Age { get; set; }
    
    public CivilType CivilStatus { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public DateTime BirthDate { get; set; }
    
    public string? Address { get; set; }
    
    public string? City { get; set; }
    
    public string? State { get; set; }
    
    public DateTimeOffset? Created { get; set; }
    
    public DateTimeOffset? Updated { get; set; }
    
    public bool IsLockedOut { get; set; }
}
