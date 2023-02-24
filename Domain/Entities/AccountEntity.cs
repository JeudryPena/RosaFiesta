namespace Domain.Entities;

public class AccountEntity
{
    public Guid Id { get; set; }
    
    public DateTime DateCreated { get; set; }
    
    public string AccountType { get; set; }
    
    public Guid OwnerId { get; set; }
}
