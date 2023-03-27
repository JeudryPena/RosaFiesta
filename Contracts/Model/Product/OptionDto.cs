namespace Contracts.Model.Product;

public class OptionDto
{
    public string Tittle { get; set; }
    public string? Description { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
    public string? Brand { get; set; } 
    public string? Color { get; set; }
    public float? Size { get; set; }
    public float Weight { get; set; }
    public int? GenderFor { get; set; } 
    public int? Material { get; set; }
    public int Condition { get; set; }
}