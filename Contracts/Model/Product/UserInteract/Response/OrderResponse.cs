using Contracts.Model.Enterprise;
using Contracts.Model.Security.Response;

namespace Contracts.Model.Product.UserInteract.Response;

public class OrderResponse : BaseResponse
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public string OrderId { get; set; }
	public string Status { get; set; }
	public string UserName { get; set; }
	public ICollection<PurchaseDetailOrderResponse> Details { get; set; }
	public string TransactionId { get; set; }
	public string CurrencyCode { get; set; }
	public string PayerId { get; set; } 
	public double Shipping { get; set; }
	public double Total { get; set; }
	public AddressDto? Address { get; set; }
	public QuoteDetailPreviewResponse? Quote { get; set; }
	public DateTimeOffset? TransactionDate { get; set; }
}