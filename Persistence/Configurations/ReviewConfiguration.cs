using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ReviewConfiguration: IEntityTypeConfiguration<ReviewEntity>
{
    private const string AdminId = "b22698b8-42a2-4115-9631-1c2d1e2ac5f7";
    private const int OptionId = 1;
    private const string ReviewId = "b22698b8-42a2-4115-9631-1c2d1e2ac5f8";
    private const string ReviewId2 = "b22698b8-42a2-4115-9631-1c2d1e2ac5f2";
    public void Configure(EntityTypeBuilder<ReviewEntity> builder)
    {
        builder.ToTable(nameof(ReviewEntity));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ReviewDescription);
        builder.Property(x => x.ReviewRating).IsRequired();
        builder.Property(x => x.ReviewDate).IsRequired();
        builder.Property(x => x.ReviewUpdateDate);
        builder.Property(x => x.ReviewTittle);
        builder.Property(x => x.UserReviewerId).IsRequired();
        builder.HasData(new ReviewEntity
        {
            Id = Guid.Parse(ReviewId),
            ReviewDescription = "Excellent",
            ReviewRating = 5,
            ReviewDate = DateTimeOffset.UtcNow,
            ReviewUpdateDate = DateTimeOffset.UtcNow,
            ReviewTittle = "Nice product",
            UserReviewerId = AdminId,
            OptionId = OptionId
        }, new ReviewEntity
        {
            Id = Guid.Parse(ReviewId2),
            ReviewDescription = "So so i liked the expierience a bit",
            ReviewRating = 3,
            ReviewDate = DateTimeOffset.UtcNow,
            ReviewUpdateDate = DateTimeOffset.UtcNow,
            ReviewTittle = "Kinda love it",
            UserReviewerId = AdminId,
            OptionId = OptionId
        });
    }
}