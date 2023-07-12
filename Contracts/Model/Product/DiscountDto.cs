namespace Contracts.Model.Product;

public class DiscountDto
{
	public double Value { get; set; }
	public DateTimeOffset Start { get; set; }
	public DateTimeOffset End { get; set; }
	public ICollection<ProductsDiscountDto>? ProductsDiscounts { get; set; }
}