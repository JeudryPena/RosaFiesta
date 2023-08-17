using Domain.Entities.Security;

namespace Domain.Entities.Product.UserInteract;

public class PayMethodEntity : BaseEntity, IAutoUpdate
{
	public Guid Id { get; set; }
	public string UserId { get; set; }
	public UserEntity? User { get; set; }
	public string OwnerName { get; set; }
	public string CardNumber { get; set; }
	public string ExpirationDate { get; set; }
	public string Cvv { get; set; }
}