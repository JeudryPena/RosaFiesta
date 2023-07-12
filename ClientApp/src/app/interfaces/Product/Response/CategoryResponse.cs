namespace Contracts.Model.Product.Response;

public class CategoryResponse : BaseResponse
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public string Icon { get; set; }
	public ICollection<ProductResponse>? Products { get; set; }
}