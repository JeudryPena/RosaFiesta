namespace Contracts.Model.Product.Response;

public class WarrantyResponse : ByBaseResponse
{
	public Guid Id { get; set; }
	public string? Name { get; set; }
	public int Type { get; set; }
	public string Status { get; set; }
	public int Period { get; set; }
	public string Description { get; set; }
	public string Conditions { get; set; }
	public IEnumerable<ProductsListResponse> Products { get; set; }
}