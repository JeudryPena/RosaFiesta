﻿using Domain.Entities.Product.UserInteract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class WishListProductsConfig: IEntityTypeConfiguration<WishListProductsEntity>
{
    public void Configure(EntityTypeBuilder<WishListProductsEntity> builder)
    {
        builder.ToTable(nameof(WishListProductsEntity));
        builder.HasKey(x => new { x.WishListId, x.ProductId });
    }
}
