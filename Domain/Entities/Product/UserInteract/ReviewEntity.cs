using Domain.Entities.Product.Helpers;
using Domain.Entities.Security;

namespace Domain.Entities.Product.UserInteract;

public class ReviewEntity
{
    public Guid Id { get; set; }
    public string? ReviewDescription { get; set; }
    public RatingType ReviewRating { get; set; }
    public DateTimeOffset ReviewDate { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset? ReviewUpdateDate { get; set; }
    public bool ConfirmedAdquisition { get; set; }
    public string? ReviewTittle { get; set; }
    public string UserReviewerId { get; set; } = string.Empty;
    public UserEntity UserEntity { get; set; } 
    /*public string? ProductId { get; set; }
    public ProductEntity ProductEntity { get; set; } */
}