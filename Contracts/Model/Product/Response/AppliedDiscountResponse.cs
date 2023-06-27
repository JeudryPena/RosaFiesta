namespace Contracts.Model.Product.Response;

public class AppliedDiscountResponse : BaseResponse
{
	public int Id { get; set; }
	public string UserId { get; set; }
	public string DiscountId { get; set; }
	public int TimesApplied { get; set; }
	public int OrderId { get; set; }
}