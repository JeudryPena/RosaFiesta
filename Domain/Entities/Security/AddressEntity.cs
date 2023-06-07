using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Security;

public class AddressEntity : BaseEntity
{
    public Guid Id { get; set; }
    [StringLength(40, MinimumLength = 1)]
    public string Title { get; set; }
    [StringLength(50, MinimumLength = 3)]
    public string Country { get; set; }
    [StringLength(100, MinimumLength = 2)]
    public string City { get; set; }
    [StringLength(10, MinimumLength = 3)]
    public string ZipCode { get; set; }
    [StringLength(60, MinimumLength = 2)]
    public string Street { get; set; }
    [StringLength(36, MinimumLength = 32)]
    public string UserId { get; set; }
    public UserEntity User { get; set; }
}