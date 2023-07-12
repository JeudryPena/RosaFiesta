using Contracts.Model.Product.Response;

namespace Contracts.Model.Product.UserInteract.Response;

public class WishListResponse : BaseResponse
{
	public int Id { get; set; }
	public ICollection<ProductPreviewResponse>? Products { get; set; }
}