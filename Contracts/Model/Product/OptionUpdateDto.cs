﻿using Contracts.Model.Product.UserInteract;

namespace Contracts.Model.Product;

public class OptionUpdateDto
{
    public string? Description { get; set; }
    public int? Price { get; set; }
    public int? Quantity { get; set; }
    public string? Brand { get; set; } 
    public string? Color { get; set; }
    public float? Size { get; set; }
    public float Weight { get; set; }
    public int? GenderFor { get; set; } 
    public int? Material { get; set; }
    public int? Condition { get; set; }
    public ICollection<MultipleImageDto>? Images { get; set; }
    public string? Thumbnail { get; set; }
    public int QuantityAvaliable { get; set; }
}