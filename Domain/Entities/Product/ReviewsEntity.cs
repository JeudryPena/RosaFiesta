using Domain.Entities.Security;

namespace Domain.Entities.Product;

public class ReviewsEntity
{
    public Guid Id { get; set; }
    public string? ReviewDescription { get; set; }
    public RatingType ReviewRating { get; set; }
    public DateTimeOffset ReviewDate { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset? ReviewUpdateDate { get; set; }
    public bool ConfirmedAdquisition { get; set; }
    public Guid PurchaseDetailId { get; set; }
    public PurchaseDetailEntity PurchaseDetailEntity { get; set; } = new();
    public string? ReviewTittle { get; set; }
    public Guid UserReviewerId { get; set; }
    public UserEntity UserEntity { get; set; } = new();
}