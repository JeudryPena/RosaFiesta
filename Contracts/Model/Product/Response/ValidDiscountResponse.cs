namespace Contracts.Model.Product.Response;

public class ValidDiscountResponse
{
    public string Code { get; set; }
    public string Type { get; set; }
    public float Value { get; set; }
    public string? Description { get; set; }
    public bool IsValid { get; set; }
    public string? ResponseMessage { get; set; }
}