namespace Contracts.Model.Product.Response;

public class CartResponse
{
    public int CartId { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
    public string? UserId { get; set; }
    public IEnumerable<PurchaseDetailResponse>? Details { get; set; }
}