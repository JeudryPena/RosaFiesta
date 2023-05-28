namespace Contracts.Model.Security;

public class FinishRegisterDto
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public Boolean PromotionalMails { get; set; } = false;
}
