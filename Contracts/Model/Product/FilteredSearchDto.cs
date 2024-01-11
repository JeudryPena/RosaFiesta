namespace Contracts.Model.Product;

/// <summary>
/// Filtered Search
/// </summary>
public sealed class FilteredSearchDto
{
    /// <summary>
    /// Product Category
    /// </summary>
    public int? CategoryId { get; set; }
    
    /// <summary>
    /// Product Condition
    /// </summary>
    public int? Condition { get; set; }
    
    /// <summary>
    /// Option Gender for
    /// </summary>
    public int? GenderFor { get; set; }
    
    /// <summary>
    /// Product Rating Average
    /// </summary>
    public float? RateAverage { get; set; }
    
    /// <summary>
    /// Product Min Price
    /// </summary>
    public int? MinPrice { get; set; }
    
    /// <summary>
    /// Product Max Price
    /// </summary>
    public int? MaxPrice { get; set; }
}