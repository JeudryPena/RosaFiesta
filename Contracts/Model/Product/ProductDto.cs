using System.ComponentModel.DataAnnotations;

namespace Contracts.Model.Product;

public class ProductDto
{
    public string Code { get; set; }
    public string Tittle { get; set; }
    public ICollection<OptionDto> Options { get; set; }
    public int Type { get; set; }
    public int? CategoryId { get; set; }
    public CategoryDto? Category { get; set; } 
    public Guid? WarrantyId { get; set; } 
    public Guid? SupplierId { get; set; }
}
