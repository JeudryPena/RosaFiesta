namespace Contracts.Model.Product.Response;

public class ProductsResponse: BaseResponse
{
    public string? Code { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public double Price { get; set; }
    public string? Image { get; set; } = string.Empty;
    public string Stock { get; set; } 
    public int? QuantityAvaliable { get; set; }
    public string? Brand { get; set; } 
    public string? Color { get; set; }
    public float? Size { get; set; }
    public float Weight { get; set; }
    public string? GenderFor { get; set; }
    public string? Material { get; set; } 
    public string Type { get; set; } 
    public string Condition { get; set; } 
    public int? CategoryId { get; set; }
    public Guid? WarrantyId { get; set; }
    public Guid? SupplierId { get; set; }
}