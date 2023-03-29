namespace Domain.Entities.Product;

public class CategoryEntity: BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public string Description { get; set; }   
    public string? Image { get; set; } 
    public string Icon { get; set; } 
    public string Slug { get; set; }
    public bool IsActive { get; set; } = true;
    public ICollection<SubCategoryEntity>? SubCategories { get; set; } 
    public ICollection<ProductEntity>? Products { get; set; } 
}