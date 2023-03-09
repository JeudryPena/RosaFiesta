using Domain.Entities.Product;
using Domain.Entities.Product.UserInteract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class BillConfiguration: IEntityTypeConfiguration<BillEntity>
{
    public void Configure(EntityTypeBuilder<BillEntity> builder)
    {
        builder.ToTable(nameof(BillEntity));
        builder.HasKey(bill => bill.NumFactura);
        builder.Property(bill => bill.TotalPrice).IsRequired();
        builder.Property(bill => bill.PaymentDate).IsRequired();
        builder.HasOne(bill => bill.User)
            .WithMany(user => user.Bills)
            .HasForeignKey(bill => bill.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(bill => bill.PayMethod)
            .WithMany(payMethod => payMethod.Bills)
            .HasForeignKey(bill => bill.PayMethodId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(bill => bill.AmmountPaid).IsRequired();
    }
}