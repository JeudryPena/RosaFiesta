namespace Contracts.Model.Product;

public class DiscountDto
{
    public string DiscountCode { get; set; } 
    public string DiscountName { get; set; } 
    public int DiscountType { get; set; }
    public float Discount { get; set; }
    public DateTimeOffset DiscountStartDate { get; set; } 
    public DateTimeOffset DiscountEndDate { get; set; } 
    public string? DiscountDescription { get; set; }
    public string? DiscountImage { get; set; }
    public ICollection<ProductsDiscountDto> ProductsDiscount { get; set; }
}