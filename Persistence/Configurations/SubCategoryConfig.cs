﻿using Domain.Entities.Product;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class SubCategoryConfig : IEntityTypeConfiguration<SubCategoryEntity>
{
    private const int SubCategory = 1;
    private const int CategoryId = 1;

    public void Configure(EntityTypeBuilder<SubCategoryEntity> builder)
    {
        builder.ToTable(nameof(SubCategoryEntity));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
        builder.HasIndex(x => x.Name).IsUnique();
        builder.Property(x => x.Description);
        builder.Property(x => x.Icon);
        builder.Property(x => x.IsActive).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt);
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.UpdatedBy);
        builder.HasData(new SubCategoryEntity
        {
            Id = SubCategory,
            Name = "Electronics",
            Description = "Electronics",
            Icon = "https://i.imgur.com/0jQYs1R.png",
            IsActive = true,
            CategoryId = CategoryId,
            CreatedAt = DateTimeOffset.UtcNow,
            CreatedBy = "System",
            UpdatedAt = DateTimeOffset.UtcNow,
            UpdatedBy = "System",
        });
    }
}