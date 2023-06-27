namespace Contracts.Model.Product.Response;

public class ProductPreviewResponse
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public OptionPreviewResponse Options { get; set; }
}