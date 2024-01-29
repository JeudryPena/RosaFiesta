namespace Contracts.Model.Product.Response;

public sealed class PurchasedProductsWithDatesResponse
{
    public DateOnly Name { get; set; }
    public int Value { get; set; }
}