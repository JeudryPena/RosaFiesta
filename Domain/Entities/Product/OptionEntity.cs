﻿using System.ComponentModel.DataAnnotations;

using Domain.Entities.Product.Helpers;
using Domain.Entities.Product.UserInteract;

namespace Domain.Entities.Product;

public class OptionEntity
{
    public int Id { get; set; }
    [StringLength(100, MinimumLength = 3)]
    public string ProductCode { get; set; }
    [StringLength(1000, MinimumLength = 3)]
    public string? Description { get; set; }
    [Range(0.01, 999999.99)]
    public double Price { get; set; }
    public DateTimeOffset? EndedAt { get; set; }
    public ICollection<MultipleOptionImages>? Images { get; set; }
    [Range(0, 1000)]
    public int QuantityAvaliable { get; set; }
    [StringLength(100, MinimumLength = 3)]
    public string? Color { get; set; }
    [Range(0, 5000)]
    public float? Size { get; set; }
    [Range(0, 5000)]
    public float Weight { get; set; }
    [StringLength(20, MinimumLength = 3)]
    public ConditionType Condition { get; set; }
    [StringLength(20, MinimumLength = 3)]
    public GenderType? GenderFor { get; set; }
    [StringLength(20, MinimumLength = 3)]
    public MaterialType? Material { get; set; }
    public ICollection<ReviewEntity>? Reviews { get; set; }
    public ICollection<ProductsDiscountsEntity>? ProductsDiscounts { get; set; }
    public ICollection<PurchaseDetailOptions>? PurchaseOptions { get; set; }
}