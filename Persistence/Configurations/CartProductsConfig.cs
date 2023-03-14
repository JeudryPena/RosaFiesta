using Domain.Entities.Product.UserInteract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class CartProductsConfig: IEntityTypeConfiguration<CartProductsEntity> 
{
    public void Configure(EntityTypeBuilder<CartProductsEntity> builder)
    {
        builder.ToTable(nameof(CartProductsEntity));
        builder.HasKey(x => new { x.CartId, x.ProductId });
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired();
        builder.Property(x => x.Quantity).IsRequired();
        
    }
}