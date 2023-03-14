namespace Contracts.Model.Product;

public class DiscountDto
{
    public string DiscountCode { get; set; } = string.Empty;
    public string DiscountName { get; set; } = string.Empty;
    public int DiscountType { get; set; }
    public float Discount { get; set; }
    public DateTimeOffset DiscountStartDate { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset DiscountEndDate { get; set; } = DateTimeOffset.Now;
    public string? DiscountDescription { get; set; }
}