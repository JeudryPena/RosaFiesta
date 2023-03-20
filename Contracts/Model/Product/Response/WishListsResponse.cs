namespace Contracts.Model.Product.Response;

public class WishListsResponse
{
    public int WishListCount => WishLists?.Count ?? 0;
    ICollection<WishListResponse>? WishLists { get; set; }
}