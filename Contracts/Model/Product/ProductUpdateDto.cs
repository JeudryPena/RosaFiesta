namespace Contracts.Model.Product;

public class ProductUpdateDto
{
	public string? Code { get; set; }
	public string? Name { get; set; }
	public string? Brand { get; set; }
	public Guid? WarrantyId { get; set; }
	public OptionDto? Option { get; set; }
}