using Domain.Entities.Product.UserInteract;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class PurchaseDetailConfig : IEntityTypeConfiguration<PurchaseDetailEntity>
{
	public void Configure(EntityTypeBuilder<PurchaseDetailEntity> builder)
	{
		builder.HasKey(x => x.DetailId);
		builder.Property(x => x.DetailId).ValueGeneratedOnAdd();
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.HasMany(x => x.PurchaseOptions).WithOne().HasForeignKey(x => x.DetailId).OnDelete(DeleteBehavior.Restrict);
	}
}