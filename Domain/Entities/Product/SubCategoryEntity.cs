namespace Domain.Entities.Product;

public class SubCategoryEntity: BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public string Description { get; set; }
    public string? Icon { get; set; } 
    public string Slug { get; set; }
    public bool IsActive { get; set; } = true;
    public int CategoryId { get; set; }
} 