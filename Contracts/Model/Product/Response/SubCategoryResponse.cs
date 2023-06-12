namespace Contracts.Model.Product.Response;

public class SubCategoryResponse : BaseResponse
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public string Icon { get; set; }
	public int CategoryId { get; set; }
	public ICollection<ProductResponse>? Products { get; set; }
}