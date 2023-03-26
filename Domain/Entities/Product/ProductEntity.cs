using System.Collections;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;

namespace Domain.Entities.Product;

public class ProductEntity: BaseEntity
{
    public ProductEntity()
    {
        Stock = StockCalculate();
    }
    public string? Code { get; set; }
    public string Title { get; set; } 
    public string? Description { get; set; }
    public double Price { get; set; }
    public DateTimeOffset? EndedAt { get; set; } 
    public string? Image { get; set; }
    public string? Thumbnail { get; set; }
    public StockStatusType Stock { get; set; }
    public int QuantityAvaliable { get; set; }
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
    public ICollection<ProductsDiscountsEntity>? Discounts { get; set; }
    public Guid? WarrantyId { get; set; }
    public WarrantyEntity? Warranty { get; set; }
    public ICollection<ReviewEntity>? Reviews { get; set; }
    public ICollection<WishListProductsEntity>? ProductsWish { get; set; }
    public ICollection<PurchaseDetailEntity>? Details { get; set; }
    public Guid? SupplierId { get; set; }
    public SupplierEntity? Supplier { get; set; }
    public ICollection<OptionEntity>? Options { get; set; }

    private StockStatusType StockCalculate()
    {
        if (QuantityAvaliable == 0)
            return StockStatusType.OutOfStock;
        if (QuantityAvaliable > 0 && QuantityAvaliable < 10)
            return StockStatusType.LowStock;
        if (QuantityAvaliable >= 10)
            return StockStatusType.InStock;
        return StockStatusType.InStock;
    }
}
