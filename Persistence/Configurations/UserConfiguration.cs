using Domain.Entities.Product.UserInteract;
using Domain.Entities.Security;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
	private const string AdminId = "b22698b8-42a2-4115-9631-1c2d1e2ac5f7";
	private const string UserId = "7D9B7113-A8F8-4035-99A7-A20DD400F6A3";
	private const string productManagerId = "2301D884-221A-4E7D-B509-0113DCC043E1";
	private const string salesManagerId = "2301D884-221A-4E7D-B509-0113DCC043E2";
	private const string marketingManagerId = "2301D884-221A-4E7D-B509-0113DCC043E3";
	private const string date1 = "1999-01-01";
	private const string date2 = "1999-01-02";
	private const string date3 = "1999-01-03";
	private const string date4 = "1999-01-04";
	private const string date5 = "1999-01-05";


	public void Configure(EntityTypeBuilder<UserEntity> builder)
	{
		builder.HasKey(user => user.Id);
		builder.HasQueryFilter(a => !a.IsDeleted);
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
			.HasForeignKey(review => review.UserId)
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
			LockoutEnabled = false,
			FullName = "Rosalba Pena",
			PhoneNumber = "18497505944",
			PhoneNumberConfirmed = true,
			TwoFactorEnabled = false,
			LockoutEnd = null,
			PromotionalMails = false,
			BirthDate = DateOnly.Parse(date1),
			IsDeleted = false
		};
		var user = new UserEntity
		{
			Id = UserId,
			UserName = "Rosanny",
			NormalizedUserName = "ROSANNY",
			Email = "rosanny@gmail.com",
			NormalizedEmail = "ROSANNY@GMAIL.COM",
			EmailConfirmed = true,
			LockoutEnabled = false,
			FullName = "Rosanny Pena",
			PhoneNumber = "18497505945",
			PhoneNumberConfirmed = true,
			TwoFactorEnabled = false,
			LockoutEnd = null,
			PromotionalMails = false,
			BirthDate = DateOnly.Parse(date2),
			IsDeleted = false
		};
		var manager = new UserEntity
		{
			Id = productManagerId,
			UserName = "Rosalba2",
			NormalizedUserName = "ROSMERY2",
			Email = "rosalbapp@gmail.com",
			NormalizedEmail = "ROSALBAPP@GMAIL.COM",
			EmailConfirmed = true,
			LockoutEnabled = false,
			FullName = "Rosalba Pena",
			PhoneNumber = "18497505946",
			PhoneNumberConfirmed = true,
			TwoFactorEnabled = false,
			LockoutEnd = null,
			PromotionalMails = false,
			BirthDate = DateOnly.Parse(date3),
			IsDeleted = false
		};
		var sales = new UserEntity
		{
			Id = salesManagerId,
			UserName = "jendry",
			NormalizedUserName = "JENDRY",
			Email = "jendrypp@gmail.com",
			NormalizedEmail = "JENDRYPP@GMAIL.COM",
			EmailConfirmed = true,
			LockoutEnabled = false,
			FullName = "Jendry Pena",
			PhoneNumber = "18497505947",
			PhoneNumberConfirmed = true,
			TwoFactorEnabled = false,
			LockoutEnd = null,
			PromotionalMails = false,
			BirthDate = DateOnly.Parse(date4),
			IsDeleted = false
		};
		var marketing = new UserEntity
		{
			Id = marketingManagerId,
			UserName = "Rosmery",
			NormalizedUserName = "ROSMERY",
			Email = "rosmerypp@gmail.com",
			NormalizedEmail = "ROSMERYPP@GMAIL.COM",
			EmailConfirmed = true,
			LockoutEnabled = false,
			FullName = "Rosmery Pena",
			PhoneNumber = "18497505948",
			PhoneNumberConfirmed = true,
			TwoFactorEnabled = false,
			LockoutEnd = null,
			PromotionalMails = false,
			BirthDate = DateOnly.Parse(date5),
			IsDeleted = false
		};
		admin.PasswordHash = PassGenerate(admin);
		user.PasswordHash = PassGenerate(user);
		manager.PasswordHash = PassGenerate(manager);
		sales.PasswordHash = PassGenerate(sales);
		marketing.PasswordHash = PassGenerate(marketing);
		builder.HasData(admin);
		builder.HasData(user);
		builder.HasData(manager);
		builder.HasData(sales);
		builder.HasData(marketing);
	}

	public string PassGenerate(UserEntity user)
	{
		var passHash = new PasswordHasher<UserEntity>();
		return passHash.HashPassword(user, "Rosanny4674$");
	}

}