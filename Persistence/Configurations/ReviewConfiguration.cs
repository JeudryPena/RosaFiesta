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
        builder.Property(x => x.Rating).IsRequired();
        builder.Property(x => x.Date).IsRequired();
        builder.Property(x => x.UpdateDate);
        builder.Property(x => x.Title);
        builder.Property(x => x.UserId).IsRequired();
        builder.HasData(new ReviewEntity
        {
            Id = Guid.Parse(ReviewId),
            Description= "Excellent",
            Rating = 5,
            Date = DateTimeOffset.UtcNow,
            UpdateDate = DateTimeOffset.UtcNow,
            Title = "Nice product",
            UserId = AdminId,
            OptionId = OptionId
        }, new ReviewEntity
        {
            Id = Guid.Parse(ReviewId2),
            Description= "So so i liked the expierience a bit",
            Rating = 3,
            Date = DateTimeOffset.UtcNow,
            UpdateDate = DateTimeOffset.UtcNow,
            Title = "Kinda love it",
            UserId = AdminId,
            OptionId = OptionId
        });
    }
}