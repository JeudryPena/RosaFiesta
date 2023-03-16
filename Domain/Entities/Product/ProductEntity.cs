using System.Collections;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;

namespace Domain.Entities.Product;

public class ProductEntity: BaseEntity
{
    public string? Code { get; set; }
    public string Name { get; set; } 
    public string? Description { get; set; }
    public int Price { get; set; }
    public DateTimeOffset? EndedAt { get; set; } 
    public string? Image { get; set; }
    public string? Thumbnail { get; set; }
    public StockStatusType Stock { get; set; } 
    public int? QuantityAvaliable { get; set; }
    public string? Brand { get; set; } 
    public string? Color { get; set; }
    public float? Size { get; set; }
    public float Weight { get; set; } 
    public GenderType? GenderFor { get; set; }
    public MaterialType? Material { get; set; } 
    public ProductType Type { get; set; } 
    public ConditionType Condition { get; set; } 
    public int? CategoryId { get; set; } 
    public CategoryEntity? Category { get; set; } 
    public string? DiscountAppliedId { get; set; }
    public DiscountEntity? DiscountApplied { get; set; } 
    public Guid? WarrantyId { get; set; }
    public WarrantyEntity? Warranty { get; set; }
    public ICollection<ReviewEntity>? Reviews { get; set; }
    public ICollection<WishListEntity>? WishListProducts { get; set; } 
    public Guid? SupplierId { get; set; }
    public SupplierEntity? Supplier { get; set; } 
    public ICollection<PurchaseDetailEntity>? Details { get; set; } 
}
