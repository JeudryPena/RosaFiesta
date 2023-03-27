using Domain.Entities;
using Domain.Entities.Product;
using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;
using Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence;

public sealed class RosaFiestaContext : IdentityDbContext<UserEntity>
{
    public const string DefaultSchema = "RosaFiesta";

    public RosaFiestaContext(DbContextOptions<RosaFiestaContext> options)
        : base(options)
    {
        Products = Set<ProductEntity>();
        Options = Set<OptionEntity>();
        Carts = Set<CartEntity>();
        Discounts = Set<DiscountEntity>();
        AppliedDiscounts = Set<AppliedDiscountEntity>();
        Orders = Set<OrderEntity>();
        PurchaseDetails = Set<PurchaseDetailEntity>();
        Categories = Set<CategoryEntity>();
        PayMethods = Set<PayMethodEntity>();
        Reviews = Set<ReviewEntity>();
        SubCategories = Set<SubCategoryEntity>();
        Suppliers = Set<SupplierEntity>();
        Warranties = Set<WarrantyEntity>();
        WishesList = Set<WishListEntity>();
        WishesListProducts = Set<WishListProductsEntity>();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RosaFiestaContext).Assembly);
        modelBuilder.HasDefaultSchema(DefaultSchema);
        modelBuilder.Entity<UserEntity>();
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<ProductEntity> Products { get; }
    public DbSet<OptionEntity> Options { get; set; }
    public DbSet<CartEntity> Carts { get; set; }
    public DbSet<DiscountEntity> Discounts { get; set; }
    public DbSet<AppliedDiscountEntity> AppliedDiscounts { get; set; }
    public DbSet<WishListEntity> WishesList { get; set; }
    public DbSet<WarrantyEntity> Warranties { get; set; }
    public DbSet<SupplierEntity> Suppliers { get; set; }
    public DbSet<SubCategoryEntity> SubCategories { get; set; }
    public DbSet<ReviewEntity> Reviews { get; set; }
    public DbSet<PayMethodEntity> PayMethods { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<PurchaseDetailEntity> PurchaseDetails { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<WishListProductsEntity> WishesListProducts { get; set; }
}
