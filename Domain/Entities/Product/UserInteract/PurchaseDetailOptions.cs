﻿namespace Domain.Entities.Product.UserInteract;

public class PurchaseDetailOptions
{
    public int PurchaseNumber { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public int? AppliedId { get; set; }
    public AppliedDiscountEntity? DiscountApplied { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public int OptionId { get; set; }
}