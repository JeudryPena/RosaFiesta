using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class DiscountConfiguration : IEntityTypeConfiguration<DiscountEntity>
{
    private const string DefaultCode = "ROSA";
    private const string DefaultCode1 = "WELCOME";

    public void Configure(EntityTypeBuilder<DiscountEntity> builder)
    {
        builder.ToTable(nameof(DiscountEntity));
        builder.HasKey(x => x.Code);
        builder.Property(x => x.Code).IsRequired();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Type).IsRequired();
        builder.Property(x => x.Value).IsRequired();
        builder.Property(x => x.MaxTimesApply).IsRequired();
        builder.Property(x => x.Start).IsRequired();
        builder.Property(x => x.End).IsRequired();
        builder.Property(x => x.Description);
        builder.Property(a => a.CreatedAt).IsRequired();
        builder.Property(a => a.UpdatedAt);
        builder.Property(a => a.CreatedBy).IsRequired();
        builder.Property(a => a.UpdatedBy);
        builder.Property(a => a.IsDeleted).IsRequired();
        builder.HasMany(x => x.ProductsDiscounts).WithOne().HasForeignKey(x => x.Code);
        builder.HasMany(x => x.AppliedDiscounts).WithOne().HasForeignKey(x => x.Code);
        builder.HasData(new DiscountEntity
        {
            Code = DefaultCode,
            Name = "Descuento Inicial",
            Value = 200,
            Type = DiscountType.Amount,
            Start = DateTimeOffset.UtcNow,
            End = new DateTimeOffset(2023, 9, 30, 0, 0, 0, TimeSpan.Zero),
            Description = "10% de descuento en todos los productos",
            MaxTimesApply = 5,
            IsDeleted = false,
            CreatedAt = DateTimeOffset.UtcNow,
            CreatedBy = "System"
        }, new DiscountEntity
        {
            Code = DefaultCode1,
            Name = "Descuento de Bienvenida",
            Value = 10,
            Type = DiscountType.Percentage,
            Start = DateTimeOffset.UtcNow,
            End = new DateTimeOffset(2023, 9, 30, 0, 0, 0, TimeSpan.Zero),
            Description = "100$ de descuento en todos los productos",
            MaxTimesApply = 1,
            IsDeleted = false,
            CreatedAt = DateTimeOffset.UtcNow,
			CreatedBy = "System"
		}

    );
    }
}