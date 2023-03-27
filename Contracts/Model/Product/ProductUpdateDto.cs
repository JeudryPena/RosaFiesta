﻿namespace Contracts.Model.Product;

public class ProductUpdateDto
{
    public string? Code { get; set; }
    public string? Tittle { get; set; } 
    public string? Description { get; set; }
    public double? Price { get; set; }
    public string? Brand { get; set; } 
    public string? Color { get; set; }
    public float? Size { get; set; }
    public int? GenderFor { get; set; } 
    public int? Material { get; set; }
    public int? Type { get; set; } 
    public int? Condition { get; set; }
    public Guid? WarrantyId { get; set; }
}