using Domain.Entities.Product.UserInteract;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class PurchaseDetailConfig : IEntityTypeConfiguration<PurchaseDetailEntity>
{
	public void Configure(EntityTypeBuilder<PurchaseDetailEntity> builder)
	{
		builder.ToTable(nameof(PurchaseDetailEntity));
		builder.HasKey(x => x.PurchaseNumber);
		builder.Property(x => x.PurchaseNumber).ValueGeneratedOnAdd();
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.Property(x => x.CartId).IsRequired();
		builder.Property(x => x.IsDeleted).HasDefaultValue(false);
		builder.Property(x => x.CreatedAt).IsRequired();
		builder.Property(x => x.UpdatedAt);
		builder.HasMany(x => x.PurchaseOptions).WithOne().HasForeignKey(x => x.PurchaseNumber).OnDelete(DeleteBehavior.Restrict);
	}
}