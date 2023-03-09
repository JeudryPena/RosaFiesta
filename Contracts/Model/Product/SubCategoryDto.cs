﻿namespace Contracts.Model.Product;

public class SubCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public string Description { get; set; }
    public string Icon { get; set; } 
    public string Slug { get; set; }
    public bool IsActive { get; set; }
    public int CategoryId { get; set; }
}