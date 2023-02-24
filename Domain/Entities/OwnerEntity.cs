namespace Domain.Entities;

public class OwnerEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
    public ICollection<AccountEntity> Accounts { get; set; }
}
