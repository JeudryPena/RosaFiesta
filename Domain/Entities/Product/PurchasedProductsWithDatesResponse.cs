namespace Domain.Entities.Product;

public sealed class PurchasedProductsWithDates
{
    public DateOnly Name { get; set; }
    public int Value { get; set; }
}