namespace Contracts.Model.Product.Response;

public class ProductResponse : ByBaseResponse
{
	public Guid Id { get; set; }
	public string Code { get; set; }
	public string Name { get; set; }
	public string? Brand { get; set; }
	public int CategoryId { get; set; }
	public int? SubCategoryId { get; set; }
	public Guid? WarrantyId { get; set; }
	public Guid? SupplierId { get; set; }
	public ICollection<OptionResponse> Options { get; set; }
}