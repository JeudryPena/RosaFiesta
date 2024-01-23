namespace Contracts.Model.Product.Response;

public class OrderPreviewResponse
{
	public Guid Id { get; set; }
	public string? OrderId { get; set; }
	public double Total { get; set; }
	public string? CurrencyCode { get; set; }
	public string? TransactionDate { get; set; }
	public string Status { get; set; }
	public Guid? QuoteId { get; set; }
}