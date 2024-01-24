using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Product.UserInteract;

public sealed class AddressEntity: BaseEntity, IAutoUpdate
{
    public Guid Id { get; set; }
    [StringLength(15, MinimumLength = 1)]
    public string? CountryCode { get; set; }
    [StringLength(15, MinimumLength = 7)]
    public string? PhoneNumber { get; set; } = string.Empty;
    [StringLength(128, MinimumLength = 3)]
    public string CustomerName { get; set; }
    [StringLength(5000, MinimumLength = 4)]
    public string? Address { get; set; }
    [StringLength(50, MinimumLength = 2)]
    public string? Description { get; set; }
    [StringLength(255, MinimumLength = 2)]
    public string? Location { get; set; }
    [StringLength(255, MinimumLength = 2)]
    public string? Province { get; set; }
    [StringLength(258, MinimumLength = 3)]
    public string Email { get; set; } = string.Empty;
    public int? PostalCode { get; set; }
}