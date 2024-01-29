namespace Contracts.Model.Product.Response;

public sealed class MostPurchasedProductsWithDatesResponse
{
    public string Name { get; set; } = string.Empty;
    public ICollection<PurchasedProductsWithDatesResponse> Series { get; set; } = new List<PurchasedProductsWithDatesResponse>();
}