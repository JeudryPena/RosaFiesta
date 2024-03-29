﻿using Domain.Entities.Product.UserInteract;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class WishListProductsConfig : IEntityTypeConfiguration<WishListProductsEntity>
{
	public void Configure(EntityTypeBuilder<WishListProductsEntity> builder)
	{
		builder.HasKey(x => new { x.WishListId, x.OptionId });
		builder.HasQueryFilter(a => !a.IsDeleted);
		builder.HasOne(x => x.Option).WithMany().HasForeignKey(x => x.OptionId);
	}
}
