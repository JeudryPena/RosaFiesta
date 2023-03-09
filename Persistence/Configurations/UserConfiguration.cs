﻿using Domain.Entities;
using Domain.Entities.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<UserEntity>
{
    private const string AdminId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";

    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable(nameof(UserEntity));
        builder.HasKey(user => user.Id);
        builder.Property(user => user.FullName).HasMaxLength(60).IsRequired();
        builder.Property(user => user.Age).IsRequired();
        builder.Property(user => user.CivilStatus).IsRequired();
        builder.Property(user => user.CreatedAt).IsRequired();
        builder.Property(user => user.UpdatedAt);
        builder.Property(user => user.BirthDate).IsRequired();
        builder.Property(user => user.Address).HasMaxLength(60);
        builder.Property(user => user.City).HasMaxLength(60);
        builder.Property(user => user.State).HasMaxLength(60);
        builder.Property(user => user.RefreshToken).HasMaxLength(60);
        builder.Property(user => user.RefreshTokenExpiryTime);
        builder.Property(user => user.Avatar).HasMaxLength(200);
        builder.HasMany(owner => owner.CartProducts)
            .WithOne(cart => cart.UserEntity)
            .HasForeignKey(cart => cart.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(owner => owner.Reviews)
            .WithOne(review => review.UserEntity)
            .HasForeignKey(review => review.UserReviewerId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(owner => owner.WishLists)
            .WithOne(wishList => wishList.UserEntity)
            .HasForeignKey(wishList => wishList.UserId)
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
            CivilStatus = CivilType.Married,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = null,
            Address = "Calle 1",
            City = "Santo Domingo",
            State = "Distrito Nacional",
            PhoneNumber = "18497505944",
            PhoneNumberConfirmed = true,
            TwoFactorEnabled = false,
            LockoutEnd = null,
            BirthDate = new DateTime(1996, 10, 10),
            Avatar = "https://i.imgur.com/1Q1Z1Zm.jpg"
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