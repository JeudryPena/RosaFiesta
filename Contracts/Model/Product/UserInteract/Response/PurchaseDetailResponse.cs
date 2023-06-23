namespace Contracts.Model.Product.UserInteract.Response;

public class PurchaseDetailResponse : BaseResponse
{
	public int PurchaseNumber { get; set; }
	public string? ProductId { get; set; }
	public double TotalOptionsPrice => PurchaseOptions.Sum(x => x.TotalPrice);
	public ICollection<PurchaseDetailOptionResponse> PurchaseOptions { get; set; }
	public int CartId { get; set; }
	public int? OrderId { get; set; }
}