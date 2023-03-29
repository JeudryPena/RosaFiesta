namespace Contracts.Model.Product.UserInteract.Response;

public class WishListsResponse
{
    public int WishListCount => WishLists?.Count ?? 0;
    ICollection<WishListPreviewResponse>? WishLists { get; set; }
}