using Domain.Entities.Product.UserInteract;
using Domain.Entities.Security;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    private const string AdminId = "b22698b8-42a2-4115-9631-1c2d1e2ac5f7";

    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable(nameof(UserEntity));
        builder.HasKey(user => user.Id);
        builder.Property(user => user.FullName).HasMaxLength(60).IsRequired();
        builder.Property(user => user.Age).IsRequired();
        builder.Property(user => user.CreatedAt).IsRequired();
        builder.Property(user => user.UpdatedAt);
        builder.Property(user => user.UpdatedBy);
        builder.Property(user => user.BirthDate).IsRequired();
        builder.Property(user => user.RefreshToken).HasMaxLength(60);
        builder.Property(user => user.RefreshTokenExpiryTime);
        builder.Property(user => user.PromotionalMails).IsRequired();
        builder.HasMany(user => user.Quotes)
            .WithOne()
            .HasForeignKey(quote => quote.UserId);
        builder.HasOne(user => user.Cart)
            .WithOne()
            .HasForeignKey<CartEntity>(cart => cart.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(user => user.Orders)
            .WithOne(order => order.User)
            .HasForeignKey(order => order.UserId);
        builder.HasMany(owner => owner.Reviews)
            .WithOne()
            .HasForeignKey(review => review.UserReviewerId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(owner => owner.WishLists)
            .WithOne()
            .HasForeignKey(wishList => wishList.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(user => user.Addresses)
            .WithOne(address => address.User)
            .HasForeignKey(address => address.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(user => user.DefaultAddress)
            .WithMany()
            .HasForeignKey(user => user.DefaultAddressId)
            .OnDelete(DeleteBehavior.SetNull);
        builder.HasOne(user => user.PayMethod)
            .WithOne()
            .HasForeignKey<UserEntity>(user => user.DefaultPayMethodId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(user => user.PayMethods)
            .WithOne(x => x.User)
            .HasForeignKey(payMethod => payMethod.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(user => user.AppliedDiscounts)
            .WithOne()
            .HasForeignKey(appliedDiscount => appliedDiscount.UserId)
            .OnDelete(DeleteBehavior.Cascade);


        var admin = new UserEntity
        {
            Id = AdminId,
            UserName = "Rosalba",
            NormalizedUserName = "ROSALBA",
            Email = "user@example.com",
            NormalizedEmail = "USER@EXAMPLE.COM",
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            LockoutEnabled = false,
            FullName = "Rosalba Pena",
            Age = 45,
            CreatedAt = DateTimeOffset.UtcNow,
            CreatedBy = "System",
            UpdatedAt = null,
            UpdatedBy = null,
            PhoneNumber = "18497505944",
            PhoneNumberConfirmed = true,
            TwoFactorEnabled = false,
            LockoutEnd = null,
            PromotionalMails = false,
            BirthDate = new DateTime(1996, 10, 10)
        };
        admin.PasswordHash = PassGenerate(admin);
        builder.HasData(admin);
    }

    public string PassGenerate(UserEntity user)
    {
        var passHash = new PasswordHasher<UserEntity>();
        return passHash.HashPassword(user, "Rosanny4674$");
    }

}