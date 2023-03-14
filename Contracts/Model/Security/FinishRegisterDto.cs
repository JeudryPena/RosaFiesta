namespace Contracts.Model.Security;

public class FinishRegisterDto
{
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int CivilStatus { get; set; } = 0;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    
    public Boolean PromotionalMails { get; set; } = false;
}
