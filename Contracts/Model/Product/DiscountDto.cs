namespace Contracts.Model.Product;

public class DiscountDto
{
    public string Code { get; set; } 
    public string Name { get; set; } 
    public int Type { get; set; }
    public float Discount { get; set; }
    public DateTimeOffset Start { get; set; } 
    public DateTimeOffset End { get; set; } 
    public string? Description { get; set; }
    public ICollection<ProductsDiscountDto> ProductsDiscount { get; set; }
}