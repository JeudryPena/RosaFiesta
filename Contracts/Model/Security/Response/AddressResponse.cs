using System.ComponentModel.DataAnnotations;

namespace Contracts.Model.Security.Response;

public class AddressResponse : BaseResponse

{
	public Guid Id { get; set; }
	[StringLength(120, MinimumLength = 3)]
	public string FullName { get; set; }
	public string PhoneNumber { get; set; }
	public string? ExtraDetails { get; set; }
	public string Title { get; set; }
	public string City { get; set; }
	public string ZipCode { get; set; }
	public string State { get; set; }
	public Guid UserId { get; set; }
}