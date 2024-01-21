using Domain.Entities.Enterprise;
using Domain.Entities.Product;
using Domain.Entities.Product.UserInteract;
using Domain.Entities.Security;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public sealed class RosaFiestaContext : IdentityDbContext<UserEntity, RoleEntity, string, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
	public const string DefaultSchema = "RosaFiesta";

	public RosaFiestaContext(DbContextOptions<RosaFiestaContext> options)
		: base(options)
	{
		Products = Set<ProductEntity>();
		OptionImages = Set<MultipleOptionImagesEntity>();
		Options = Set<OptionEntity>();
		Carts = Set<CartEntity>();
		Discounts = Set<DiscountEntity>();
		ProductsDiscounts = Set<ProductsDiscountsEntity>();
		Orders = Set<OrderEntity>();
		PurchaseDetails = Set<PurchaseDetailEntity>();
		PurchaseDetailsOptions = Set<PurchaseDetailOptions>();
		Categories = Set<CategoryEntity>();
		Reviews = Set<ReviewEntity>();
		Suppliers = Set<SupplierEntity>();
		Warranties = Set<WarrantyEntity>();
		WishesList = Set<WishListEntity>();
		WishesListProducts = Set<WishListProductsEntity>();
		Quotes = Set<QuoteEntity>();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(RosaFiestaContext).Assembly);
		modelBuilder.HasDefaultSchema(DefaultSchema);
		modelBuilder.Entity<UserEntity>().ToTable("Users");
		modelBuilder.Entity<RoleEntity>().ToTable("Roles");
		modelBuilder.Entity<UserClaim>().ToTable("UserClaims");
		modelBuilder.Entity<UserRole>().ToTable("UserRoles");
		modelBuilder.Entity<UserLogin>().ToTable("UserLogins");
		modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims");
		modelBuilder.Entity<UserToken>().ToTable("UserTokens");

		modelBuilder.Entity<UserEntity>()
		.HasMany(u => u.UserRoles)
		.WithOne(u => u.User)
		.HasForeignKey(ur => ur.UserId);
		modelBuilder.Entity<UserRole>().HasOne(ur => ur.Role).WithMany(x => x.UserRoles).HasForeignKey(ur => ur.RoleId);
	}

	public DbSet<ProductEntity> Products { get; }
	public DbSet<OptionEntity> Options { get; set; }
	public DbSet<MultipleOptionImagesEntity> OptionImages { get; set; }
	public DbSet<CartEntity> Carts { get; set; }
	public DbSet<DiscountEntity> Discounts { get; set; }
	public DbSet<ProductsDiscountsEntity> ProductsDiscounts { get; set; }
	public DbSet<WishListEntity> WishesList { get; set; }
	public DbSet<WarrantyEntity> Warranties { get; set; }
	public DbSet<SupplierEntity> Suppliers { get; set; }
	public DbSet<ReviewEntity> Reviews { get; set; }
	public DbSet<CategoryEntity> Categories { get; set; }
	public DbSet<PurchaseDetailEntity> PurchaseDetails { get; set; }
	public DbSet<PurchaseDetailOptions> PurchaseDetailsOptions { get; set; }
	public DbSet<OrderEntity> Orders { get; set; }
	public DbSet<WishListProductsEntity> WishesListProducts { get; set; }
	public DbSet<QuoteEntity> Quotes { get; set; }
}
