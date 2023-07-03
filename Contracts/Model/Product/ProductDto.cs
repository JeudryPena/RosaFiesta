namespace Contracts.Model.Product;

public class ProductDto
{
	public string? Code { get; set; }
	public string Name { get; set; }
	public string? Brand { get; set; }
	public ICollection<OptionDto> Options { get; set; }
	public int CategoryId { get; set; }
	public int? SubCategoryId { get; set; }
	public Guid? WarrantyId { get; set; }
	public Guid? SupplierId { get; set; }
}
