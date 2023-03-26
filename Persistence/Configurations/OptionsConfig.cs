using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class OptionsConfig : IEntityTypeConfiguration<OptionEntity>
{
    public void Configure(EntityTypeBuilder<OptionEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(product => product.Title).HasMaxLength(40).IsRequired();
        builder.Property(product => product.Description).HasMaxLength(200);
        builder.Property(product => product.Price).IsRequired();
        builder.Property(product => product.EndedAt);
        builder.Property(product => product.Image).HasMaxLength(500);
        builder.Property(product => product.Stock).IsRequired();
        builder.Property(product => product.QuantityAvaliable).IsRequired();
        builder.Property(product => product.Brand).HasMaxLength(40);
        builder.Property(product => product.Color).HasMaxLength(15);
        builder.Property(product => product.Size);
        builder.Property(product => product.Weight);
        builder.Property(product => product.GenderFor);
        builder.Property(product => product.Material);
        builder.Property(product => product.Thumbnail).HasMaxLength(500);
        builder.Property(product => product.Condition).IsRequired();
        
        builder.HasOne(x => x.Product).WithMany(x => x.Options).HasForeignKey(x => x.ProductCode);
        builder.HasMany(x => x.PurchaseDetails).WithOne(x => x.Option).HasForeignKey(x => x.OptionId);
        builder.HasMany(x => x.WishListsProducts).WithOne(x => x.Option).HasForeignKey(x => x.OptionId);
    }
}