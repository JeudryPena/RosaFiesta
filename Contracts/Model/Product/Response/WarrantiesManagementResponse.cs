namespace Contracts.Model.Product.Response;
public class WarrantiesManagementResponse : ByBaseResponse
{
	public Guid Id { get; set; }
	public string? Name { get; set; }
	public string Type { get; set; }
	public string Status { get; set; }
	public int Period { get; set; }
	public string Description { get; set; }
	public IEnumerable<ProductsListResponse> Products { get; set; }
}
