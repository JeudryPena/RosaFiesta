using Domain.Entities.Product.UserInteract;

namespace Domain.Entities.Product;

public class DiscountEntity : ByBaseEntity, IAutoBy
{
	public Guid Id { get; set; }
	public double Value { get; set; }
	public DateTimeOffset Start { get; set; }
	public DateTimeOffset End { get; set; }
	public ICollection<ProductsDiscountsEntity>? ProductsDiscounts { get; set; }
	public ICollection<PurchaseDetailOptions>? AppliedOptions { get; set; }
}