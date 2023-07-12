namespace Contracts.Model.Product.Response;

public class ProductResponse : ByBaseResponse
{
	public Guid Id { get; set; }
	public string Code { get; set; }
	public bool IsService { get; set; }
	public int CategoryId { get; set; }
	public Guid? WarrantyId { get; set; }
	public Guid? SupplierId { get; set; }
	public ICollection<OptionsResponse> Options { get; set; }
}