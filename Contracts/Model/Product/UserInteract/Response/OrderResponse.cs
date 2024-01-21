using Contracts.Model.Security.Response;

namespace Contracts.Model.Product.UserInteract.Response;

public class OrderResponse : BaseResponse
{
	public string OrderId { get; set; }
	public int State { get; set; }
	public string UserId { get; set; }
	public int VoucherNumber { get; set; }
	public ICollection<PurchaseDetailResponse> Details { get; set; }
}