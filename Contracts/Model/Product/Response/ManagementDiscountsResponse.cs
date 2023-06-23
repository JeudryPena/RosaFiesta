namespace Contracts.Model.Product.Response;
public class ManagementDiscountsResponse : BaseResponse
{
	public string Code { get; set; } = string.Empty;
	public string Name { get; set; }
	public int Type { get; set; }
	public double Value { get; set; }
	public int MaxTimesApply { get; set; }
	public DateTimeOffset Start { get; set; }
	public DateTimeOffset End { get; set; }
	public string CreatedBy { get; set; }
	public string? UpdatedBy { get; set; }
	public string? Description { get; set; }
	public ICollection<ProductsDiscountResponse>? ProductsDiscounts { get; set; }

}
