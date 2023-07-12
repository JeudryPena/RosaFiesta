namespace Contracts.Model.Product.Response;

public class ProductsDiscountResponse
{
	public Guid DiscountId { get; set; }
	public Guid OptionId { get; set; }
	public OptionsListResponse Option { get; set; }
}