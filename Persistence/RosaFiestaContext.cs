using Domain.Entities.Enterprise;
using Domain.Entities.Product;
using Domain.Entities.Product.UserInteract;
using Domain.Entities.Security;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence;

public sealed class RosaFiestaContext : IdentityDbContext<UserEntity>
{
	public const string DefaultSchema = "RosaFiesta";
	private IConfiguration Configuration { get; }

	public RosaFiestaContext(DbContextOptions<RosaFiestaContext> options, IConfiguration configuration)
		: base(options)
	{
		Configuration = configuration;
		Addresses = Set<AddressEntity>();
		Products = Set<ProductEntity>();
		OptionImages = Set<MultipleOptionImages>();
		Options = Set<OptionEntity>();
		Carts = Set<CartEntity>();
		Discounts = Set<DiscountEntity>();
		ProductsDiscounts = Set<ProductsDiscountsEntity>();
		AppliedDiscounts = Set<AppliedDiscountEntity>();
		Orders = Set<OrderEntity>();
		PurchaseDetails = Set<PurchaseDetailEntity>();
		PurchaseDetailsOptions = Set<PurchaseDetailOptions>();
		Categories = Set<CategoryEntity>();
		PayMethods = Set<PayMethodEntity>();
		Reviews = Set<ReviewEntity>();
		SubCategories = Set<SubCategoryEntity>();
		Suppliers = Set<SupplierEntity>();
		Warranties = Set<WarrantyEntity>();
		WishesList = Set<WishListEntity>();
		WishesListProducts = Set<WishListProductsEntity>();
		Quotes = Set<QuoteEntity>();
		QuoteItems = Set<QuoteItemEntity>();
		Services = Set<ServiceEntity>();
		ActionLogs = Set<ActionLogEntity>();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(RosaFiestaContext).Assembly);
		modelBuilder.HasDefaultSchema(DefaultSchema);
		modelBuilder.Entity<UserEntity>();

		base.OnModelCreating(modelBuilder);
	}

	public DbSet<AddressEntity> Addresses { get; set; }
	public DbSet<ProductEntity> Products { get; }
	public DbSet<OptionEntity> Options { get; set; }
	public DbSet<MultipleOptionImages> OptionImages { get; set; }
	public DbSet<CartEntity> Carts { get; set; }
	public DbSet<DiscountEntity> Discounts { get; set; }
	public DbSet<AppliedDiscountEntity> AppliedDiscounts { get; set; }
	public DbSet<ProductsDiscountsEntity> ProductsDiscounts { get; set; }
	public DbSet<WishListEntity> WishesList { get; set; }
	public DbSet<WarrantyEntity> Warranties { get; set; }
	public DbSet<SupplierEntity> Suppliers { get; set; }
	public DbSet<SubCategoryEntity> SubCategories { get; set; }
	public DbSet<ReviewEntity> Reviews { get; set; }
	public DbSet<PayMethodEntity> PayMethods { get; set; }
	public DbSet<CategoryEntity> Categories { get; set; }
	public DbSet<PurchaseDetailEntity> PurchaseDetails { get; set; }
	public DbSet<PurchaseDetailOptions> PurchaseDetailsOptions { get; set; }
	public DbSet<OrderEntity> Orders { get; set; }
	public DbSet<WishListProductsEntity> WishesListProducts { get; set; }

	public DbSet<ServiceEntity> Services { get; set; }

	public DbSet<QuoteItemEntity> QuoteItems { get; set; }

	public DbSet<QuoteEntity> Quotes { get; set; }

	public DbSet<ActionLogEntity> ActionLogs { get; set; }
}
