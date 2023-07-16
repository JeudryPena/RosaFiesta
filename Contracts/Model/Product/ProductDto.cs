namespace Contracts.Model.Product;

public class ProductDto
{
	public string? Code { get; set; }
	public bool IsService { get; set; }
	public ICollection<OptionDto> Options { get; set; }
	public int OptionIndex { get; set; }
	public int CategoryId { get; set; }
	public Guid? WarrantyId { get; set; }
	public Guid? SupplierId { get; set; }
}
