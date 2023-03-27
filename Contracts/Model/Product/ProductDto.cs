using System.ComponentModel.DataAnnotations;

namespace Contracts.Model.Product;

public class ProductDto
{
    public string Code { get; set; }
    public string Tittle { get; set; }
    public string? Description { get; set; }
    public int Price { get; set; }
    public ICollection<OptionDto>? Options { get; set; }
    public int QuantityAvaliable { get; set; }
    public string? Brand { get; set; } 
    public string? Color { get; set; }
    public float? Size { get; set; }
    public float Weight { get; set; }
    public int? GenderFor { get; set; } 
    public int? Material { get; set; } 
    public int Type { get; set; } 
    public int Condition { get; set; }
    public int? CategoryId { get; set; }
    public CategoryDto? Category { get; set; }
    public Guid? WarrantyId { get; set; } 
    public Guid? SupplierId { get; set; }
}
