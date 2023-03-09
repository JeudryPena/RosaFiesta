namespace Domain.Entities.Product;

public class SubCategoryEntity: BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = "Cumpleaños";
    public string Description { get; set; } = "Decoraciones";  
    public string Image { get; set; } = "https://via.placeholder.com/150";
    public string Icon { get; set; } = "fa fa-list";
    public string Slug { get; set; } = "active";
    public bool IsActive { get; set; } 
    public int CategoryId { get; set; } 
    public CategoryEntity Category { get; set; } 
} 