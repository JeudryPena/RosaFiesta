namespace Contracts.Model.Security;

public class AddressDto
{
	public string Title { get; set; }
	public string City { get; set; }
	public string ZipCode { get; set; }
	public string Street { get; set; }
	public string? ExtraDetail { get; set; }
}