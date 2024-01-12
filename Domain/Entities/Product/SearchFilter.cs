namespace Domain.Entities.Product;

/// <summary>
/// Filtered Search entity
/// </summary>
public sealed class SearchFilter
{
       /// <summary>
       /// Search Value
       /// </summary>
       public string? SearchValue { get; set; }
       
       /// <summary>
       /// Product Category
       /// </summary>
       public int? CategoryId { get; set; }
       
       /// <summary>
       /// Product Condition
       /// </summary>
       public int? Condition { get; set; }
       
       /// <summary>
       /// Product Rating Average
       /// </summary>
       public float? Rating { get; set; }
       
       /// <summary>
       /// Product Min Price
       /// </summary>
       public int? StartValue { get; set; }
       
       /// <summary>
       /// Product Max Price
       /// </summary>
       public int? EndValue { get; set; } 
}