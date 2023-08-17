namespace Contracts.Model.Product.UserInteract;
public class PayMethodDto
{
	public string OwnerName { get; set; }
	public string CardNumber { get; set; }
	public string ExpirationDate { get; set; }
	public string Cvv { get; set; }
}
