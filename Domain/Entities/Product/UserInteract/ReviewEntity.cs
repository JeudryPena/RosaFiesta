using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Product.UserInteract;

public class ReviewEntity
{
    public Guid Id { get; set; }
    [StringLength(250, MinimumLength = 3)]
    public string? ReviewDescription { get; set; }
    [Range(0, 5)]
    public float ReviewRating { get; set; }
    public DateTimeOffset ReviewDate { get; set; }
    public DateTimeOffset? ReviewUpdateDate { get; set; }
    [StringLength(50, MinimumLength = 3)]
    public string? ReviewTittle { get; set; }
    public string UserReviewerId { get; set; }
    public int OptionId { get; set; }
}