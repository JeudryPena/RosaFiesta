using Domain.Entities.Product.Helpers;
using Domain.Entities.Security;

namespace Domain.Entities.Product.UserInteract;

public class ReviewEntity
{
    public Guid Id { get; set; }
    public string? ReviewDescription { get; set; }
    public float ReviewRating { get; set; }
    public DateTimeOffset ReviewDate { get; set; } 
    public DateTimeOffset? ReviewUpdateDate { get; set; }
    public string? ReviewTittle { get; set; }
    public string UserReviewerId { get; set; } 
    public UserEntity UserEntity { get; set; } 
    public string? ProductId { get; set; }
    public ProductEntity ProductEntity { get; set; } 
}