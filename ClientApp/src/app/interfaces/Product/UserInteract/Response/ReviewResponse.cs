namespace Contracts.Model.Product.UserInteract.Response;

public class ReviewResponse : BaseResponse
{
	public Guid Id { get; set; }
	public string? Description { get; set; }
	public float Rating { get; set; }
	public string? Title { get; set; }
	public string UserId { get; set; }
	public Guid OptionId { get; set; }
}