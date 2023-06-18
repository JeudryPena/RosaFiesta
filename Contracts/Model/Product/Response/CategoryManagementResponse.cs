namespace Contracts.Model.Product.Response;
public class CategoryManagementResponse : BaseResponse
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Icon { get; set; }
	public string? Description { get; set; }
	public string CreatedBy { get; set; }
	public string UpdatedBy { get; set; }
	public ICollection<SubCategoryPreviewResponse>? SubCategories { get; set; }
}
