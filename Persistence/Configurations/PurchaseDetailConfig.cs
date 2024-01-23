using Domain.Entities.Product.UserInteract;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class PurchaseDetailConfig : IEntityTypeConfiguration<PurchaseDetailEntity>
{
	public void Configure(EntityTypeBuilder<PurchaseDetailEntity> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id).ValueGeneratedOnAdd();
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.HasMany(x => x.PurchaseOptions).WithOne(x => x.Detail).HasForeignKey(x => x.DetailId).OnDelete(DeleteBehavior.Cascade);
		builder.HasOne(x => x.Warranty)
			.WithMany()
			.HasForeignKey(x => x.WarrantyId);
	}
}