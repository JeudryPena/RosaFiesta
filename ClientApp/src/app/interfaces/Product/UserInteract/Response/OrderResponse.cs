using Contracts.Model.Security.Response;

namespace Contracts.Model.Product.UserInteract.Response;

public class OrderResponse : BaseResponse
{
	public Guid Id { get; set; }
	public Guid PayMethodId { get; set; }
	public int State { get; set; }
	public string UserId { get; set; }
	public double ShippingCost { get; set; }
	public string VoucherType { get; set; }
	public int VoucherNumber { get; set; }
	public string VoucherSeries { get; set; }
	public double TaxesCost { get; set; }
	public ICollection<PurchaseDetailResponse> Details { get; set; }
	public Guid AddressId { get; set; }
	public AddressResponse Address { get; set; }
}