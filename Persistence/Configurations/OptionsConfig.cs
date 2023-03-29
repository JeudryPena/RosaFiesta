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
    public void Configure(EntityTypeBuilder<OptionEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(product => product.Title).HasMaxLength(40).IsRequired();
        builder.Property(product => product.Description).HasMaxLength(200);
        builder.Property(product => product.Price).IsRequired();
        builder.Property(product => product.EndedAt);
        builder.Property(product => product.Image).HasMaxLength(500);
        builder.Property(product => product.QuantityAvaliable).IsRequired();
        builder.Property(product => product.Brand).HasMaxLength(40);
        builder.Property(product => product.Color).HasMaxLength(15);
        builder.Property(product => product.Size);
        builder.Property(product => product.Weight);
        builder.Property(product => product.GenderFor);
        builder.Property(product => product.Material);
        builder.Property(product => product.Thumbnail).HasMaxLength(500);
        builder.Property(product => product.Condition).IsRequired();
        builder.HasMany(product => product.WishListProducts)
            .WithOne(wish => wish.Option)
            .HasForeignKey(wish => wish.OptionId);
        builder.HasMany(product => product.Reviews)
            .WithOne(review => review.Option)
            .HasForeignKey(review => review.OptionId);

        builder.HasData(new OptionEntity
        {
            Id = OptionId,
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
            Id = OptionId2,
            Title = "Polo",
            Description = "Polo de manga corta",
            Price = 800,
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