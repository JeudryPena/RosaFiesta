using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Security;

public class AddressEntity : BaseEntity, IAutoUpdate
{
	public Guid Id { get; set; }
	[StringLength(250, MinimumLength = 3)]
	public string ExtraDetails { get; set; }
	[StringLength(50, MinimumLength = 1)]
	public string Title { get; set; }
	[StringLength(100, MinimumLength = 2)]
	public string City { get; set; }
	[StringLength(10, MinimumLength = 3)]
	public string ZipCode { get; set; }
	[StringLength(60, MinimumLength = 2)]
	public string State { get; set; }
	[StringLength(120, MinimumLength = 3)]
	public string FullName { get; set; }
	[StringLength(20, MinimumLength = 3)]
	public string PhoneNumber { get; set; }
	public string UserId { get; set; }
	public UserEntity User { get; set; }
}