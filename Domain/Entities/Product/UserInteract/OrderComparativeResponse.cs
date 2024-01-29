namespace Domain.Entities.Product.UserInteract;

public sealed class OrderComparative
{
    public OrderComparativeData Orders { get; set; } = new();
    public OrderComparativeData Quotes { get; set; } = new();
    public OrderComparativeData NotPurchased { get; set; } = new();
    public OrderComparativeData Refunds { get; set; } = new();
}