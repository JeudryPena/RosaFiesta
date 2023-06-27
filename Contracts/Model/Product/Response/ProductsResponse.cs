namespace Contracts.Model.Product.Response;
public class ProductsResponse : BaseResponse
{
	public Guid Id { get; set; }
	public string? Code { get; set; }
	public string Title { get; set; }
	public OptionsResponse Option { get; set; }
}
