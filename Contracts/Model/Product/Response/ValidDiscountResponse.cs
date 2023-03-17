namespace Contracts.Model.Product.Response;

public class ValidDiscountResponse
{
    public string DiscountCode { get; set; } = string.Empty;
    public string DiscountName { get; set; } = string.Empty;
    public string DiscountType { get; set; }
    public float Discount { get; set; }
    public DateTimeOffset DiscountStartDate { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset DiscountEndDate { get; set; } = DateTimeOffset.Now;
    public string? DiscountDescription { get; set; }
    public bool IsValid { get; set; }
    public string? ResponseMessage { get; set; }
}