namespace Contracts.Model.Product.Response;

public class ProductsDiscountResponse : BaseResponse
{
	public string ProductCode { get; set; }
	public string Code { get; set; }
	public int OptionId { get; set; }
}