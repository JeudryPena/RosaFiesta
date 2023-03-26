using Contracts.Model.Product.UserInteract.Response;

namespace Contracts.Model.Product.Response;

public class DiscountResponse: BaseResponse
{
    public string DiscountCode { get; set; } = string.Empty;
    public string DiscountName { get; set; } = string.Empty;
    public string DiscountType { get; set; }
    public float Discount { get; set; }
    public DateTimeOffset DiscountStartDate { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset DiscountEndDate { get; set; } = DateTimeOffset.Now;
    public string? DiscountDescription { get; set; }
    public string? DiscountImage { get; set; }
    public string? DiscountCodeImage { get; set; }
    public ICollection<ProductsResponse>? DiscountProducts { get; set; }
    public ICollection<PurchaseDetailResponse>? DiscountPurchases { get; set;}
}