namespace Contracts.Model.Security.Response;

public class AddressResponse
{
    public Guid Id { get; set; }
    public string Tittle { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string Street { get; set; }
    public Guid UserId { get; set; }
}