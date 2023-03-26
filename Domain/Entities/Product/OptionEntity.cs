﻿using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;

namespace Domain.Entities.Product;

public class OptionEntity
{
    public OptionEntity()
    {
        Stock = StockCalculate();
    }
    public int Id { get; set; }
    public ProductEntity Product { get; set; }
    public int ProductCode { get; set; }
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
    public ConditionType Condition { get; set; }
    public GenderType? GenderFor { get; set; }
    public MaterialType? Material { get; set; }
    public ICollection<PurchaseDetailEntity>? PurchaseDetails { get; set; }
    public ICollection<ReviewEntity>? Reviews { get; set; } 
    public ICollection<WishListProductsEntity>? WishListsProducts { get; set; }

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