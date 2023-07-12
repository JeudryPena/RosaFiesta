namespace Contracts.Model.Product;

public class SupplierDto
{
	public string Name { get; set; }
	public string? Email { get; set; }
	public string? Phone { get; set; }
	public string? Description { get; set; }
	public string? Address { get; set; }
	public ICollection<ProductsDto>? Products { get; set; }
}