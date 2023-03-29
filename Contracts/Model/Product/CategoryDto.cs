namespace Contracts.Model.Product;

public class CategoryDto
{
    public string Name { get; set; } 
    public string Description { get; set; }
    public string Icon { get; set; } 
    public string Slug { get; set; }
    public bool IsActive { get; set; } = false;
    public SubCategoryDto[]? SubCategories { get; set; } = Array.Empty<SubCategoryDto>();
}