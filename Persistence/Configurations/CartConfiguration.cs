using Domain.Entities.Product;
using Domain.Entities.Product.UserInteract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class CartConfiguration: IEntityTypeConfiguration<CartEntity>
{
    private const int CartId = 1;
    private const string AdminId = "b22698b8-42a2-4115-9631-1c2d1e2ac5f7";
    public void Configure(EntityTypeBuilder<CartEntity> builder)
    {
        builder.ToTable(nameof(CartEntity));
        builder.HasKey(x => x.CartId);
        builder.Property(x => x.UserId).IsRequired();
        // i want my many to one realtion with details to not cascade delete
        builder.HasMany(x => x.Details).WithOne(x => x.Cart).HasForeignKey(x => x.CartId);
        builder.HasData( new CartEntity { 
            CartId = CartId,
            UserId = AdminId,
        });
    }
}