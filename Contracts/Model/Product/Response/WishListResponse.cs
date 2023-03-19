namespace Contracts.Model.Product.Response;

public class WishListResponse
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset CreatedDate { get; set; } 
    public DateTimeOffset? UpdatedDate { get; set; }
    public ICollection<ProductsResponse>? Products { get; set; }
    public string UserId { get; set; }
}