namespace Contracts.Model.Product.Response;

public class ProductsDiscountResponse
{
	public string DiscountId { get; set; }
	public int OptionId { get; set; }
	public string Title => Option.Title;
	public OptionsListResponse Option { get; set; }
}