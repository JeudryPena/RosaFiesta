using System.Collections;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;

namespace Domain.Entities.Product;

public class ProductEntity: BaseEntity
{
    public string? Code { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int Price { get; set; }
    public DateTimeOffset? EndedAt { get; set; } 
    public string? Image { get; set; } = string.Empty;
    public StockStatusType Stock { get; set; } = StockStatusType.InStock;
    public int? QuantityAvaliable { get; set; } = 1;
    public string? Brand { get; set; } 
    public string? Color { get; set; }
    public float? Size { get; set; }
    public GenderType? GenderFor { get; set; }
    public MaterialType? Material { get; set; } = MaterialType.Other;
    public ProductType Type { get; set; } = ProductType.Physical;
    public ConditionType Condition { get; set; } = ConditionType.New;
    public int? CategoryId { get; set; } 
    public CategoryEntity? Category { get; set; } 
    public string? DiscountAppliedId { get; set; }
    public DiscountEntity? DiscountApplied { get; set; } 
    public Guid? WarrantyId { get; set; }
    public WarrantyEntity? Warranty { get; set; } 
    /*public ReviewEntity Review { get; set; } = new();*/
    public ICollection<CartEntity>? CartProducts { get; set; } 
    public ICollection<WishListEntity>? WishListProducts { get; set; } 
    public Guid? SupplierId { get; set; }
    public SupplierEntity? Supplier { get; set; } 
    public ICollection<PurchaseDetailEntity>? Details { get; set; } 
}
