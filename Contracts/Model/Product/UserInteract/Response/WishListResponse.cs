using Contracts.Model.Product.Response;

namespace Contracts.Model.Product.UserInteract.Response;

public class WishListResponse : BaseResponse
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public ICollection<ProductPreviewResponse>? Products { get; set; }
}