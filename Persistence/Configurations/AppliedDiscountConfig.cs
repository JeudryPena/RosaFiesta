using Domain.Entities.Product.UserInteract;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class AppliedDiscountConfig : IEntityTypeConfiguration<AppliedDiscountEntity>
{
	public void Configure(EntityTypeBuilder<AppliedDiscountEntity> builder)
	{
		builder.HasKey(ad => ad.Id);
		builder.Property(ad => ad.Id).ValueGeneratedOnAdd();
		builder.HasQueryFilter(b => !b.IsDeleted);
	}
}