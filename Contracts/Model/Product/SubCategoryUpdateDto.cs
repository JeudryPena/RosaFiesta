namespace Contracts.Model.Product;

public class SubCategoryUpdateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public bool IsActive { get; set; }
    public int CategoryId { get; set; }
}