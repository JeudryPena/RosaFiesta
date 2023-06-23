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
		builder.Property(a => a.CreatedAt).IsRequired().ValueGeneratedOnAdd();
		builder.Property(a => a.UpdatedAt).ValueGeneratedOnUpdate();
		builder.HasQueryFilter(b => !b.IsDeleted);
		builder.Property(ad => ad.UserId).IsRequired();
		builder.Property(ad => ad.Code).IsRequired();
	}
}