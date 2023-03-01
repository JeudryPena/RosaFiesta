using Domain.Entities;
using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class ProductConfiguration: IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable(nameof(ProductEntity));
        builder.HasKey(owner => owner.Id);
        builder.Property(owner => owner.Name).HasMaxLength(60);
        builder.Property(owner => owner.Description).HasMaxLength(100);
        builder.Property(owner => owner.Price).IsRequired();
        builder.Property(owner => owner.IsAvailable).IsRequired();
        builder.Property(owner => owner.CreatedAt).IsRequired();
    }
}