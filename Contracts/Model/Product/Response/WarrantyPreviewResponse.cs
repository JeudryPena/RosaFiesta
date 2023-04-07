﻿namespace Contracts.Model.Product.Response;

public class WarrantyPreviewResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; } 
    public string Type { get; set; } 
    public string ScopeType { get; set; }
    public string? Status { get; set; }
    public string Period { get; set; } 
    public string Description { get; set; }
    public string Conditions { get; set; } 
}