namespace Contracts.Model.Product.Response;

public class DiscountResponse
{
	public Guid Id { get; set; }
	public double Value { get; set; }
	public DateTimeOffset Start { get; set; }
	public DateTimeOffset End { get; set; }
	public ICollection<HotestProductsResponse>? ProductsDiscounts { get; set; }
}