namespace Domain.Entities.Product;

public class CategoryEntity: BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = "Cumpleaños";
    public string Description { get; set; } = "Lorem ipsum dolor";     
    public string Image { get; set; } = "https://via.placeholder.com/150";
    public string Icon { get; set; } = "fa fa-list";
    public string Slug { get; set; } = "active";    
    public bool IsActive { get; set; } = false;
    public ICollection<SubCategoryEntity>? SubCategories { get; set; } 
    public ICollection<ProductEntity>? Products { get; set; } 
}