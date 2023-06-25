﻿using Domain.Entities.Product.UserInteract;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class PurchaseDetailOptionsConfig : IEntityTypeConfiguration<PurchaseDetailOptions>
{

	public void Configure(EntityTypeBuilder<PurchaseDetailOptions> builder)
	{
		builder.HasKey(x => new { x.PurchaseNumber, x.OptionId });
		builder.Property(x => x.PurchaseNumber).ValueGeneratedOnAdd();
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.HasOne(x => x.DiscountApplied).WithOne(x => x.PurchaseOption).HasForeignKey<PurchaseDetailOptions>(x => x.AppliedId);
	}
}