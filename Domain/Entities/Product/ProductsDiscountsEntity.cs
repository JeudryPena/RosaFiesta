﻿namespace Domain.Entities.Product;

public class ProductsDiscountsEntity
{
    public string ProductCode { get; set; }
    public ProductEntity Product { get; set; }
    public string DiscountCode { get; set; }
    public DiscountEntity Discount { get; set; }
}