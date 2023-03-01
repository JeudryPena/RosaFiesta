using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Product;

public class ProductEntity: BaseEntity
{
    public string? Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int Price { get; set; } = 0;
    public bool IsAvailable { get; set; } = true;
    public DateTimeOffset? EndedAt { get; set; } 
    public string? Image { get; set; } = string.Empty;
    public StockStatusType Stock { get; set; } = StockStatusType.InStock;
    public int? QuantityAvaliable { get; set; } = 0;
    public string? Brand { get; set; } 
    public string? Color { get; set; }
    public string? Size { get; set; }
    public string? GenderFor { get; set; }
    public MaterialType? Material { get; set; } = MaterialType.Other;
    public ProductType Type { get; set; } = ProductType.Physical;
    public ConditionType Condition { get; set; } = ConditionType.New;
    public int CategoryId { get; set; } 
    public CategoryEntity CategoryEntity { get; set; } = new();
    public ICollection<DiscountEntity>? DiscountsAvailable
    { get; set; } = new List<DiscountEntity>();
    public ICollection<WarrantyEntity>? WarrantiesAvailable
    { get; set; } = new List<WarrantyEntity>();
    public ICollection<PurchaseDetailEntity>? ProductPurchases { get; set; } = new List<PurchaseDetailEntity>();
    public ICollection<ReviewsEntity>? ProductReviews { get; set; } = new List<ReviewsEntity>();
    public ICollection<CartEntity>? CartProducts { get; set; } = new List<CartEntity>();
    public ICollection<WishListEntity>? WishListProducts { get; set; } = new List<WishListEntity>();
    public ICollection<SupplierEntity> Suppliers { get; set; } = new List<SupplierEntity>();
}
