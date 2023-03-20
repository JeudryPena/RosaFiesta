using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ReviewConfiguration: IEntityTypeConfiguration<ReviewEntity>
{
    private const string AdminId = "b22698b8-42a2-4115-9631-1c2d1e2ac5f7";
    private const string ProductId = "SDA01";
    public void Configure(EntityTypeBuilder<ReviewEntity> builder)
    {
        builder.ToTable(nameof(ReviewEntity));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ReviewDescription).HasMaxLength(500);
        builder.Property(x => x.ReviewRating).IsRequired();
        builder.Property(x => x.ReviewDate).IsRequired();
        builder.Property(x => x.ReviewUpdateDate);
        builder.Property(x => x.ReviewTittle).HasMaxLength(100);

        builder.HasData(new ReviewEntity
        {
            Id = Guid.NewGuid(),
            ReviewDescription = "Excellent",
            ReviewRating = 5,
            ReviewDate = DateTimeOffset.UtcNow,
            ReviewUpdateDate = DateTimeOffset.UtcNow,
            ReviewTittle = "Nice product",
            UserReviewerId = AdminId,
            ProductId = ProductId,
        });
    }
}