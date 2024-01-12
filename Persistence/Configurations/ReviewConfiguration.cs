using Domain.Entities.Product.UserInteract;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<ReviewEntity>
{
	public void Configure(EntityTypeBuilder<ReviewEntity> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id).ValueGeneratedOnAdd();
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.HasOne(review => review.User)
			.WithMany()
			.HasForeignKey(review => review.UserId);
	}
}