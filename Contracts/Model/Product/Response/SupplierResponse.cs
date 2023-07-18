namespace Contracts.Model.Product.Response;

public class SupplierResponse : ByBaseResponse
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string? Email { get; set; }
	public string? Description { get; set; }
	public string? Phone { get; set; }
	public string? Address { get; set; }
	public ICollection<ProductsListResponse>? Products { get; set; }
}