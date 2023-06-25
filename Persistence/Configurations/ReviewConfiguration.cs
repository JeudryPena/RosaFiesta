using Domain.Entities.Product.UserInteract;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<ReviewEntity>
{
	public void Configure(EntityTypeBuilder<ReviewEntity> builder)
	{
		builder.ToTable(nameof(ReviewEntity));
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id).ValueGeneratedOnAdd();
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.Property(x => x.Description);
		builder.Property(x => x.Rating).IsRequired();
		builder.Property(a => a.CreatedAt).IsRequired();
		builder.Property(a => a.UpdatedAt);
		builder.Property(a => a.IsDeleted).IsRequired();
		builder.Property(x => x.Title);
		builder.Property(x => x.UserId).IsRequired();
	}
}