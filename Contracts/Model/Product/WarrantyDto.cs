namespace Contracts.Model.Product;

public class WarrantyDto
{
	public string Name { get; set; }
	public int Type { get; set; }
	public int Period { get; set; }
	public int Status { get; set; }
	public string Description { get; set; }
	public string Conditions { get; set; }
	public ICollection<WarrantyProductsDto>? Products { get; set; }
}