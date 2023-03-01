namespace Domain.Entities.Product;

public class SubCategoryEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = "Lorem ipsum dolor sit amet";
    public string Description { get; set; } = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam auctor semper ligula";     
    public string Image { get; set; } = "https://via.placeholder.com/150";
    public string Icon { get; set; } = "fa fa-list";
    public string Slug { get; set; } = "active";
    public string Status { get; set; } = "Active";
    public Guid CategoryId { get; set; } 
    public CategoryEntity Category { get; set; } = new();
    public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset? UpdatedDate { get; set; }
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
}