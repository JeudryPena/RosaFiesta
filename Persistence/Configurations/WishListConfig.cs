using Domain.Entities.Product.UserInteract;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class WishListConfig : IEntityTypeConfiguration<WishListEntity>
{
    public void Configure(EntityTypeBuilder<WishListEntity> builder)
    {
        builder.HasKey(w => w.Id);
        builder.Property(w => w.Title);
        builder.HasIndex(x => x.Title).IsUnique();
        builder.Property(w => w.Description);
        builder.Property(w => w.CreatedDate);
        builder.Property(w => w.UpdatedDate);
        builder.Property(w => w.UserId).IsRequired();
        builder.HasMany(x => x.ProductsWish)
            .WithOne()
            .HasForeignKey(x => x.WishListId);

    }
}