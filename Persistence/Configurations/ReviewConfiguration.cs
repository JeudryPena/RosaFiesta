using Domain.Entities.Product;
using Domain.Entities.Product.UserInteract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ReviewConfiguration: IEntityTypeConfiguration<ReviewEntity>
{
    public void Configure(EntityTypeBuilder<ReviewEntity> builder)
    {
        builder.ToTable(nameof(ReviewEntity));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ReviewDescription).HasMaxLength(500);
        builder.Property(x => x.ReviewRating).IsRequired();
        builder.Property(x => x.ReviewDate).IsRequired();
        builder.Property(x => x.ReviewUpdateDate);
        builder.Property(x => x.ReviewTittle).HasMaxLength(100);
    }
}