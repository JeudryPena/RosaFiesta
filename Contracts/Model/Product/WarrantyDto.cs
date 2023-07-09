namespace Contracts.Model.Product;

public class WarrantyDto
{
	public string Name { get; set; }
	public int Type { get; set; }
	public int Period { get; set; }
	public string Description { get; set; }
	public string Conditions { get; set; }
	public ICollection<ProductsDto>? WarrantyProducts { get; set; }
}