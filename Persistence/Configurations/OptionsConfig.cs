using System.Runtime.InteropServices.ComTypes;
using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class OptionsConfig : IEntityTypeConfiguration<OptionEntity>
{
    private const string ProductId = "SDA01";
    public void Configure(EntityTypeBuilder<OptionEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
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
        builder.HasMany(x => x.PurchaseDetails).WithOne(x => x.Option).HasForeignKey(x => x.OptionId);
        builder.HasMany(x => x.WishListsProducts).WithOne(x => x.Option).HasForeignKey(x => x.OptionId);
        builder.HasMany(x => x.Reviews).WithOne(x => x.OptionEntity).HasForeignKey(x => x.OptionId);

        builder.HasData(new OptionEntity
        {
            Title = "Polo plus",
            Description = "Polo de manga larga",
            Price = 1200,
            EndedAt = null,
            Image =
                "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.amazon.com%2FChampion-Reverse-Weave-Polo-White%2Fdp%2FB07G1J7Q2Q&psig=AOvVaw2D5N7VQ2v0uL7zS9O4yJ7l&ust=162812",
            QuantityAvaliable = 8,
            Brand = "Champion",
            Color = "Gold",
            Size = 1.7f,
            Weight = 0.7f,
            GenderFor = GenderType.Both,
            Material = MaterialType.Cotton,
            Condition = ConditionType.New,
            ProductCode = ProductId,
        }, new OptionEntity
        {
            Title = "Polo",
            Description = "Polo de manga corta",
            Price = 1000,
            EndedAt = null,
            Image =
                "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.amazon.com%2FChampion-Reverse-Weave-Polo-White%2Fdp%2FB07G1J7Q2Q&psig=AOvVaw2D5N7VQ2v0uL7zS9O4yJ7l&ust=1628125928634000&source=images&cd=vfe&ved=0CAsQjRxqFwoTCOjGqfCg1_ICFQAAAAAdAAAAABAD",
            QuantityAvaliable = 10,
            Brand = "Champion",
            Color = "White",
            Size = 1.5f,
            Weight = 0.5f,
            GenderFor = GenderType.Both,
            Material = MaterialType.Cotton,
            Condition = ConditionType.New,
            ProductCode = ProductId,
        });
    }
}