namespace Domain.Entities.Product;

public sealed class MostPurchasedProductsWithDates
{
    public string Name { get; set; } = string.Empty;
    public ICollection<PurchasedProductsWithDates> Series { get; set; } = new List<PurchasedProductsWithDates>();
}