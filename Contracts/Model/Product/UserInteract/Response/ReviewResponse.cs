namespace Contracts.Model.Product.UserInteract.Response;

public class ReviewResponse
{
    public Guid Id { get; set; }
    public string? ReviewDescription { get; set; }
    public float ReviewRating { get; set; }
    public DateTimeOffset ReviewDate { get; set; } 
    public DateTimeOffset? ReviewUpdateDate { get; set; }
    public string? ReviewTittle { get; set; }
    public string UserReviewerId { get; set; }
}