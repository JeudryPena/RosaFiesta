namespace Contracts.Model.Product;

public class SupplierDto
{
	public string Name { get; set; } = String.Empty;
	public string? Email { get; set; }
	public string? Phone { get; set; }
	public string? Description { get; set; }
	public string Address { get; set; } = String.Empty;
	public ICollection<ProductsDto>? Products { get; set; }
}