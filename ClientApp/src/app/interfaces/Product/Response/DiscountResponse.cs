namespace Contracts.Model.Product.Response;

public class DiscountResponse : BaseResponse
{
	public Guid Id { get; set; }
	public double Value { get; set; }
	public DateTimeOffset Start { get; set; } 
	public DateTimeOffset End { get; set; } 
	public ICollection<ProductsDiscountResponse>? ProductsDiscounts { get; set; }
}