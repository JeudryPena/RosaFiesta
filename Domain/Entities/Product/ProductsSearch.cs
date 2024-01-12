namespace Domain.Entities.Product;

/// <summary>
/// Filtered Search
/// </summary>
public sealed class ProductsSearch
{
    /// <summary>
    /// Search Value
    /// </summary>
    public string? SearchValue { get; set; }
    
    /// <summary>
    /// Product Category
    /// </summary>
    public int? CategoryId { get; set; }
}