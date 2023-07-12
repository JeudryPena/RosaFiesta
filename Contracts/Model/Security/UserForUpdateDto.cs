namespace Contracts.Model.Security;

public class UserForUpdateDto
{
	public string UserName { get; set; }
	public string Name { get; set; }
	public string LastName { get; set; }
	public DateOnly BirthDate { get; set; }
	public IEnumerable<string> RoleId { get; set; }
}