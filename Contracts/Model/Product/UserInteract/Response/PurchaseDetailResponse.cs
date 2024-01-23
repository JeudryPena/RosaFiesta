using Contracts.Model.Product.Response;

namespace Contracts.Model.Product.UserInteract.Response;

public class PurchaseDetailResponse : BaseResponse
{
	public Guid Id { get; set; }
	public Guid ProductId { get; set; }
	public ICollection<PurchaseDetailOptionResponse> PurchaseOptions { get; set; }
	public Guid? OrderId { get; set; }
	public Guid? QuoteId { get; set; }
	public Guid? WarrantyId { get; set; }
	public WarrantyPreviewResponse? Warranty { get; set; }
}