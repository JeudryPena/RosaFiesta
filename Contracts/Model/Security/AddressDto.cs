namespace Contracts.Model.Security;

public class AddressDto
{
	public string Title { get; set; }
	public string Name { get; set; }
	public string LastName { get; set; }
	public string PhoneNumber { get; set; }
	public string City { get; set; }
	public string ZipCode { get; set; }
	public string State { get; set; }
	public string? ExtraDetails { get; set; }
}