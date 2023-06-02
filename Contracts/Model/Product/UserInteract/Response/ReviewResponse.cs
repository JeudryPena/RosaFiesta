namespace Contracts.Model.Product.UserInteract.Response;

public class ReviewResponse
{
    public Guid Id { get; set; }
    public string? Description{ get; set; }
    public float Rating { get; set; }
    public DateTimeOffset Date { get; set; } 
    public DateTimeOffset? UpdateDate { get; set; }
    public string? Title { get; set; }
    public string UserId { get; set; }
    public string ProductCode { get; set; } 
    public int? OptionId { get; set; } 
}