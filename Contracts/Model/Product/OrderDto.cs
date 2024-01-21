namespace Contracts.Model.Product;

public sealed class OrderDto
{
    public string OrderId { get; set; }
    public AddressDto Address { get; set; }
    public double Total { get; set; }
    public string? TransactionId { get; set; }
    public string? CurrencyCode { get; set; }
    public string? PayerId { get; set; }
    public double? Shipping { get; set; }
    public DateTimeOffset? TransactionDate { get; set; }
}