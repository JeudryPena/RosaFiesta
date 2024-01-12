namespace Contracts.Model.Product;

/// <summary>
/// Filtered Search simplified
/// </summary>
public sealed class SearchProductsDto
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