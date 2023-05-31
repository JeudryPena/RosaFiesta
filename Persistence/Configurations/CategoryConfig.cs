﻿using Domain.Entities.Product;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class CategoryConfig : IEntityTypeConfiguration<CategoryEntity>
{
    private const int CategoryId = 1;

    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.ToTable(nameof(CategoryEntity));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Name).IsRequired();
        builder.HasIndex(x => x.Name).IsUnique();
        builder.Property(x => x.Description);
        builder.Property(x => x.Icon);
        builder.Property(x => x.IsActive).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt);
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.UpdatedBy);
        builder.HasMany(x => x.SubCategories).WithOne().HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Cascade);
        builder.HasData(new CategoryEntity
        {
            Id = CategoryId,
            Name = "Peluches",
            Description = "Peluches de todos los tipos",
            Icon = "https://i.imgur.com/0jQYs1R.png",
            IsActive = true,
            CreatedAt = DateTimeOffset.UtcNow,
            CreatedBy = "System",
            UpdatedAt = DateTimeOffset.UtcNow,
            UpdatedBy = "System",
        });
    }
}