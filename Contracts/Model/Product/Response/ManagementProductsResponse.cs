namespace Contracts.Model.Product.Response;
public class ManagementProductsResponse : ByBaseResponse
{
	public Guid Id { get; set; }
	public string? Code { get; set; }
	public bool IsService { get; set; }
	public CategoriesListResponse Category { get; set; }
	public SubCategoriesListResponse? SubCategory { get; set; }
	public IEnumerable<OptionsListResponse> Options { get; set; }
}
