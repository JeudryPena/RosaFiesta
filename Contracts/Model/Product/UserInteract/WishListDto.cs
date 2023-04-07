namespace Contracts.Model.Product.UserInteract;

public class WishListDto
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public ICollection<int> OptionsId { get; set; }
}