﻿using Domain.Entities.Product;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ProductsDiscountsConfig : IEntityTypeConfiguration<ProductsDiscountsEntity>
{
	public void Configure(EntityTypeBuilder<ProductsDiscountsEntity> builder)
	{
		builder.ToTable(nameof(ProductsDiscountsEntity));
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id).ValueGeneratedOnAdd();
		builder.Property(a => a.CreatedAt).IsRequired().ValueGeneratedOnAdd();
		builder.Property(a => a.UpdatedAt).ValueGeneratedOnUpdate();
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.HasOne(x => x.Option).WithMany(x => x.ProductsDiscounts).HasForeignKey(x => x.OptionId);
	}
}