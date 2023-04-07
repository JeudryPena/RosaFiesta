namespace Contracts.Model.Product.Response;

public class ValidDiscountResponse
{
    public string DiscountCode { get; set; }
    public string DiscountType { get; set; }
    public float DiscountValue { get; set; }
    public string? DiscountDescription { get; set; }
    public bool IsValid { get; set; }
    public string? ResponseMessage { get; set; }
}