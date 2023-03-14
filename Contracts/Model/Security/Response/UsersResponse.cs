namespace Contracts.Model.Security.Response;

public class UsersResponse
{
    public Guid Id { get; set; }
    
    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;
    
    public int Age { get; set; }
    
    public string CivilStatus { get; set; } = string.Empty;
    
    public DateTimeOffset CreatedAt { get; set; }
    
    public DateTimeOffset? UpdatedAt { get; set; }
    
    public DateTimeOffset BirthDate { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;

    public bool TwoFactorEnabled { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool EmailConfirmed { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public string? PasswordHash { get; set; }
    
    public string? Address { get; set; }
    
    public string? City { get; set; }
    
    public string? State { get; set; }

    public bool IsLockedOut { get; set; } 
    
    public bool PromotionalMails { get; set; }
}
