using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class PayMethodConfiguration: IEntityTypeConfiguration<PayMethodEntity>
{
    private const string PayMethodId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F4";
    private const string UserId = "b22698b8-42a2-4115-9631-1c2d1e2ac5f7";
    public void Configure(EntityTypeBuilder<PayMethodEntity> builder)
    {
        builder.ToTable(nameof(PayMethodEntity));
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Description).IsRequired().HasMaxLength(100);
        builder.Property(e => e.CreatedDate).IsRequired();
        builder.Property(e => e.UpdatedDate).IsRequired(false);
        builder.Property(e => e.PayMethodType).IsRequired();

        builder.HasData( new PayMethodEntity
        {
            Id = Guid.Parse(PayMethodId),
            Name = "Cash",
            Description = "Cash payment",
            PayMethodType = PayMethodType.Cash,
            CreatedDate = DateTimeOffset.Now,
            UserId = UserId
        });
    }
}