using Domain.Entities.Product;
using Domain.Entities.Product.UserInteract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class CartConfiguration: IEntityTypeConfiguration<CartEntity>
{
    private const int CartId = 1;
    private const string AdminId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";
    public void Configure(EntityTypeBuilder<CartEntity> builder)
    {
        builder.ToTable(nameof(CartEntity));
        builder.HasKey(x => x.CartId);
        builder.Property(x => x.UserId).IsRequired();
        builder.HasMany(x => x.Details).WithOne(x => x.Cart).HasForeignKey(x => x.CartId);
        builder.HasData( new CartEntity { 
            CartId = CartId,
            UserId = AdminId,
        });
    }
}