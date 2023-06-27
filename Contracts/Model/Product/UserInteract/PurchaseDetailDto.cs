namespace Contracts.Model.Product.UserInteract;

public class PurchaseDetailDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public int OptionId { get; set; }
}