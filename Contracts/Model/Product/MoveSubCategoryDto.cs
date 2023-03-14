namespace Contracts.Model.Product;

public class MoveSubCategoryDto
{
    public int CategoryId { get; set; }
    public int SubCategoryId { get; set; }
    public int NewCategoryId { get; set; }
}