using Domain.Entities.Product.UserInteract;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class PurchaseDetailOptionsConfig : IEntityTypeConfiguration<PurchaseDetailOptions>
{

	public void Configure(EntityTypeBuilder<PurchaseDetailOptions> builder)
	{
		builder.ToTable(nameof(PurchaseDetailOptions));
		builder.HasKey(x => new { x.PurchaseNumber, x.OptionId });
		builder.Property(x => x.PurchaseNumber).ValueGeneratedOnAdd();
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.Property(x => x.Quantity).IsRequired();
		builder.Property(x => x.UnitPrice).IsRequired();
		builder.Property(x => x.AppliedId);
		builder.Property(x => x.CreatedAt).IsRequired();
		builder.Property(x => x.UpdatedAt);
		builder.Property(x => x.OptionId).IsRequired();
		builder.Property(x => x.IsReturned);
		builder.HasOne(x => x.DiscountApplied).WithOne(x => x.PurchaseOption).HasForeignKey<PurchaseDetailOptions>(x => x.AppliedId);
	}
}