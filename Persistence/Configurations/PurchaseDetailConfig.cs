using Domain.Entities.Product.UserInteract;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class PurchaseDetailConfig : IEntityTypeConfiguration<PurchaseDetailEntity>
{
	public void Configure(EntityTypeBuilder<PurchaseDetailEntity> builder)
	{
		builder.ToTable(nameof(PurchaseDetailEntity));
		builder.HasKey(x => new { x.PurchaseNumber });
		builder.Property(x => x.PurchaseNumber).ValueGeneratedOnAdd();
		builder.Property(a => a.CreatedAt).IsRequired().ValueGeneratedOnAdd();
		builder.Property(a => a.UpdatedAt).ValueGeneratedOnUpdate();
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.Property(x => x.CartId).IsRequired();
		builder.Property(x => x.IsDeleted).HasDefaultValue(false);
		builder.Property(x => x.CreatedAt).IsRequired();
		builder.Property(x => x.UpdatedAt);
		builder.HasMany(x => x.PurchaseOptions).WithOne().HasForeignKey(x => x.PurchaseNumber).OnDelete(DeleteBehavior.Restrict);
	}
}