namespace Contracts.Model.Product.Response;

public class DiscountResponse : BaseResponse
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; }
    public double Value { get; set; }
    public int MaxTimesApply { get; set; }
    public DateTimeOffset Start { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset End { get; set; } = DateTimeOffset.Now;
    public string? Description { get; set; }
    public ICollection<ProductsDiscountResponse> ProductsDiscounts { get; set; }
}