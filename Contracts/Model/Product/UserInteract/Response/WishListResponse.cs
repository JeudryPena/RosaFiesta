using Contracts.Model.Product.Response;

namespace Contracts.Model.Product.UserInteract.Response;

public class WishListResponse
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset CreatedDate { get; set; } 
    public DateTimeOffset? UpdatedDate { get; set; }
    public ICollection<ProductPreviewResponse>? Products { get; set; }
}