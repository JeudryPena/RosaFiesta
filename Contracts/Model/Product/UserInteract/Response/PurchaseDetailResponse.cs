namespace Contracts.Model.Product.UserInteract.Response;

public class PurchaseDetailResponse : BaseResponse
{
	public Guid PurchaseNumber { get; set; }
	public Guid ProductId { get; set; }
	public ICollection<PurchaseDetailOptionResponse> PurchaseOptions { get; set; }
	public Guid CartId { get; set; }
	public Guid? OrderId { get; set; }
	public Guid? QuoteId { get; set; }
}