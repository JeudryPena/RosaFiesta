using Contracts.Model.Product.Response;

namespace Contracts.Model.Product.UserInteract.Response;

public class PurchaseDetailOptionResponse : BaseResponse
{
	public Guid DetailId { get; set; }
	public OptionCartResponse Option { get; set; }
	public int Quantity { get; set; }
	public Guid OptionId { get; set; }
	public double UnitPrice { get; set; }
	public Guid? AppliedId { get; set; }
	public bool IsReturned { get; set; }
}