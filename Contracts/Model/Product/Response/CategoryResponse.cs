namespace Contracts.Model.Product.Response;

public class CategoryResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public bool IsActive { get; set; }
    public ICollection<SubCategoryResponse>? SubCategories { get; set; }
    public ICollection<ProductAndOptionResponse>? Products { get; set; }
}