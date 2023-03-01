using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<UserEntity>
{
    private const string AdminId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";

    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        var admin = new UserEntity
        {
            Id = AdminId,
            UserName = "user@example.com",
            NormalizedUserName = "USER@EXAMPLE.COM",
            Email = "user@example.com",
            NormalizedEmail = "USER@EXAMPLE.COM",
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            LockoutEnabled = false,
            FullName = "Rosalba Pena",
            Age = 45,
            CivilStatus = CivilType.Married,
            CreatedAt = DateTimeOffset.Now,
            UpdatedAt = null,
            Address = "Calle 1",
            City = "Santo Domingo",
            State = "Distrito Nacional",
            PhoneNumber = "18497505944",
            PhoneNumberConfirmed = true,
            TwoFactorEnabled = false,
            LockoutEnd = null,
            BirthDate = new DateTime(1996, 10, 10),
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