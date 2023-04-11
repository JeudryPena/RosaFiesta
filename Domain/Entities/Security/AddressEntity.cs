using Domain.Entities.Product.UserInteract;

namespace Domain.Entities.Security;

public class AddressEntity
{
    public Guid Id { get; set; }
    public string Tittle { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string Street { get; set; }
    public string UserId { get; set; }
    public UserEntity User { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}