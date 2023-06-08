namespace Contracts.Model.Product.Response;

public class CategoryPreviewResponse
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Icon { get; set; }
	public string? Description { get; set; }
	public ICollection<SubCategoryPreviewResponse>? SubCategories { get; set; }
}