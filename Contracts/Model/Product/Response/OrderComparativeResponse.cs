namespace Contracts.Model.Product.Response;

public sealed class OrderComparativeResponse
{
    public OrderComparativeDataResponse Orders { get; set; } = new();
    public OrderComparativeDataResponse Quotes { get; set; } = new();
    public OrderComparativeDataResponse NotPurchased { get; set; } = new();
    public OrderComparativeDataResponse Refunds { get; set; } = new();
}