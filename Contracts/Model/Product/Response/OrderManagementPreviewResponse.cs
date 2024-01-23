namespace Contracts.Model.Product.Response;

public sealed class OrderManagementPreviewResponse
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? OrderId { get; set; }
    public double Total { get; set; }
    public string? CurrencyCode { get; set; }
    public string? TransactionDate { get; set; }
    public string Status { get; set; }
    public string? UserId { get; set; }
    public AddressDto Address { get; set; }
    public Guid QuoteId { get; set; }
}