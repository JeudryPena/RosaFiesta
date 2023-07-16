namespace Contracts.Model.Product.Response;

public class ProductResponse : ByBaseResponse
{
	public Guid Id { get; set; }
	public string Code { get; set; }
	public bool IsService { get; set; }
	public OptionsResponse Option { get; set; }
	public CategoriesListResponse Category { get; set; }
	public SuppliersListResponse? SupplierId { get; set; }
	public WarrantiesListResponse? Warranty { get; set; }
	public ICollection<OptionsResponse> Options { get; set; }
}