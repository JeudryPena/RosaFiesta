using Contracts.Model.Product.UserInteract.Response;

namespace Contracts.Model.Product.Response;

public class DiscountResponse: BaseResponse
{
    public string DiscountCode { get; set; } = string.Empty;
    public string DiscountName { get; set; } = string.Empty;
    public string DiscountType { get; set; }
    public double DiscountValue { get; set; }
    public int MaxTimesApply { get; set; }
    public DateTimeOffset DiscountStartDate { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset DiscountEndDate { get; set; } = DateTimeOffset.Now;
    public string? DiscountDescription { get; set; }
    public string? DiscountImage { get; set; }
    public ICollection<ProductsDiscountResponse> ProductsDiscounts { get; set; } 
}