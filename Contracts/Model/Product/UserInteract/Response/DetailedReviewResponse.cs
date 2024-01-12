using Contracts.Model.Security.Response;

namespace Contracts.Model.Product.UserInteract.Response;

public class DetailedReviewResponse
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public float Rating { get; set; }
    public string? Title { get; set; }
    public string UserId { get; set; }
    public UsersListResponse User { get; set; } 
    public Guid OptionId { get; set; }
}