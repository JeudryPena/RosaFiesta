using Contracts.Model.Product.Response;

namespace Contracts.Model.Product;

public class WishListDto
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public ICollection<string>? ProductsId { get; set; }
}