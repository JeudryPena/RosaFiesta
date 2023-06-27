namespace Contracts.Model.Product.Response;
public class ManagementDiscountsResponse : ByBaseResponse
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public int Type { get; set; }
	public double Value { get; set; }
	public int MaxTimesApply { get; set; }
	public DateTimeOffset Start { get; set; }
	public DateTimeOffset End { get; set; }
	public string? Description { get; set; }
	public ICollection<ProductsDiscountResponse>? ProductsDiscounts { get; set; }

}
