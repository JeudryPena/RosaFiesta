namespace Contracts.Model.Product.Response;
public class ProductsListResponse
{
	public Guid Id { get; set; }
	public OptionsPreviewListResponse? Option { get; set; }
}
