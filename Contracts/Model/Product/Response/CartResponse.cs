using Contracts.Model.Product.UserInteract.Response;

namespace Contracts.Model.Product.Response;

public class CartResponse
{
    public int CartId { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
    public string? UserId { get; set; }
    public int TotalCartQuantity => Details?.Sum(x => x.PurchaseOptions.Count) ?? 0;
    public double TotalCartPrice => Details?.Sum(x => x.TotalOptionsPrice) ?? 0;
    public IEnumerable<PurchaseDetailResponse>? Details { get; set; }
}