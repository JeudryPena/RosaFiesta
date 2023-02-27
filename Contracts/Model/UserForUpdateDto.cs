namespace Contracts.Model;

public class UserForUpdateDto
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public int CivilStatus { get; set; }
    public DateTimeOffset BirthDate { get; set; } 
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}