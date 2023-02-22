using System.ComponentModel.DataAnnotations;
using Core.Security;
using Microsoft.AspNetCore.Identity;

namespace Core.Models;

public class UserEntity : IdentityUser
{
    [Required]
    public Guid ID { get; set; }

    [MinLength(3), MaxLength(50)]
    [Required]
    public string Name { get; set; } = string.Empty;

    [MinLength(3), MaxLength(50)]
    [Required]
    public string LastName { get; set; } = string.Empty;

    [MinLength(3), MaxLength(50)]
    public string? DisplayName { get; set; }

    [Range(5, 130)]
    [Required]
    public int Age { get; set; }

    [Required]
    public CivilType CivilStatus { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime? UpdatedAt { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime BirthDate { get; set; }

    [MinLength(3), MaxLength(70)]
    public string? Address { get; set; }

    [MinLength(3), MaxLength(25)]
    public string? City { get; set; }

    [MinLength(3), MaxLength(25)]
    public string? State { get; set; }

    [Range(1000, 99999)]
    public int? ZipCode { get; set; }

    [DataType(DataType.DateTime)]
    public DateTimeOffset? Created { get; set; }

    [DataType(DataType.DateTime)]
    public DateTimeOffset? Updated { get; set; }

    public string CreatedBy { get; set; } = string.Empty;

    public string? UpdatedBy { get; set; }

    [Required]
    public bool IsLockedOut { get; set; }
}
