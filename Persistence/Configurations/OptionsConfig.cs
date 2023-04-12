using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class OptionsConfig : IEntityTypeConfiguration<OptionEntity>
{
    private const string ProductId = "SDA01";
    private const int OptionId = 1;
    private const int OptionId2 = 2;
    private const int OptionId3 = 3;
    private const string ProductId2 = "SDA02";
    public void Configure(EntityTypeBuilder<OptionEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Description).HasMaxLength(200);
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.EndedAt);
        builder.Property(x => x.QuantityAvaliable).IsRequired();
        builder.Property(x => x.Color).HasMaxLength(15);
        builder.Property(x => x.Size);
        builder.Property(x => x.Weight);
        builder.Property(x => x.GenderFor);
        builder.Property(x => x.Material);
        builder.Property(x => x.Condition).IsRequired();
        builder.HasMany(product => product.Reviews)
            .WithOne()
            .HasForeignKey(review => review.OptionId);
        builder.HasMany(option => option.PurchaseOptions)
            .WithOne()
            .HasForeignKey(purchaseOption => purchaseOption.OptionId);
        builder.HasMany(option => option.Images)
            .WithOne()
            .HasForeignKey(image => image.OptionId);

        builder.HasData(new OptionEntity
        {
            Id = OptionId,
            Description = "Polo de manga larga",
            Price = 1200,
            EndedAt = null,
            QuantityAvaliable = 8,
            Color = "Gold",
            Size = 1.7f,
            Weight = 0.7f,
            GenderFor = GenderType.Both,
            Material = MaterialType.Cotton,
            Condition = ConditionType.New,
            ProductCode = ProductId,
        }, new OptionEntity
        {
            Id = OptionId2,
            Description = "Polo de manga corta",
            Price = 800,
            EndedAt = null,
            QuantityAvaliable = 10,
            Color = "White",
            Size = 1.5f,
            Weight = 0.5f,
            GenderFor = GenderType.Both,
            Material = MaterialType.Cotton,
            Condition = ConditionType.New,
            ProductCode = ProductId,
        }, new OptionEntity()
        {
            Id = OptionId3,
            Description = "Polo XL",
            Price = 1400,
            EndedAt = null,
            QuantityAvaliable = 10,
            Color = "Green",
            Size = 2.0f,
            Weight = 1.0f,
            GenderFor = GenderType.Both,
            Material = MaterialType.Cotton,
            Condition = ConditionType.Used,
            ProductCode = ProductId2,
        });
    }
}