namespace Contracts.Model.Product.UserInteract;

public class PurchaseDetailDto
{
    public string ProductId { get; set; }
    public int Quantity { get; set; }
    public int OptionId { get; set; }
}