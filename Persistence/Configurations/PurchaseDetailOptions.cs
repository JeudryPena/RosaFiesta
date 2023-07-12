using Domain.Entities.Product.UserInteract;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class PurchaseDetailOptionsConfig : IEntityTypeConfiguration<PurchaseDetailOptions>
{

	public void Configure(EntityTypeBuilder<PurchaseDetailOptions> builder)
	{
		builder.HasKey(x => new { x.DetailId, x.OptionId });
		builder.Property(x => x.DetailId).ValueGeneratedOnAdd();
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.HasOne(x => x.Discount).WithMany(x => x.AppliedOptions).HasForeignKey(x => x.AppliedId);
	}
}