using Contracts.Model.Product.UserInteract.Response;

namespace Contracts.Model.Product.Response;

public class CartResponse
{
    public int CartId { get; set; }
    public string? UserId { get; set; }
    public IEnumerable<PurchaseDetailResponse>? Details { get; set; }
}