namespace Contracts.Model.Product.UserInteract.Response;

public class PurchaseDetailOptionResponse : BaseResponse
{
	public string Image { get; set; }
	public int Quantity { get; set; }
	public Guid OptionId { get; set; }
	public double UnitPrice { get; set; }
	public Guid? AppliedId { get; set; }
	public bool IsReturned { get; set; }
}