using System.ComponentModel.DataAnnotations;

namespace Contracts.Model.Product;

public class ProductEntityDto
{
    public string? Code { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int Price { get; set; }
    public int? Quantity { get; set; } = 0;
    public string? Brand { get; set; } 
    public string? Color { get; set; }
    public float? Size { get; set; }
    public int? GenderFor { get; set; } = 3;
    public int? Material { get; set; } = 1;
    public int Type { get; set; } = 1;
    public int Condition { get; set; } = 1;
    public int? CategoryId { get; set; } 
    
    public CategoryDto? Category { get; set; }
    public Guid? WarrantyId { get; set; } 
    public Guid? SupplierId { get; set; }
}
