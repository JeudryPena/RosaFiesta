namespace Contracts.Model;

public class PostRegisterDto
{
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int CivilStatus { get; set; } = 0;
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
}
