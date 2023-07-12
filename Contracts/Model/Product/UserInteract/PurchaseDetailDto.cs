namespace Contracts.Model.Product.UserInteract;

public class PurchaseDetailDto
{
	public Guid ProductId { get; set; }
	public int Quantity { get; set; }
	public Guid OptionId { get; set; }
}