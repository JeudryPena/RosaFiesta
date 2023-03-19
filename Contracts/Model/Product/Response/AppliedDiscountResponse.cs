namespace Contracts.Model.Product.Response;

public class AppliedDiscountResponse
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string DiscountCode { get; set; }
    public int TimesApplied { get; set; }
    public DateTimeOffset AppliedDate { get; set; }
    public int OrderId { get; set; }
}