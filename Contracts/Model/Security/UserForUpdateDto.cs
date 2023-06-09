namespace Contracts.Model.Security;

public class UserForUpdateDto
{
	public string Name { get; set; }
	public string LastName { get; set; }
	public DateOnly BirthDate { get; set; }
	public string Address { get; set; }
	public string City { get; set; }
	public string State { get; set; }
}