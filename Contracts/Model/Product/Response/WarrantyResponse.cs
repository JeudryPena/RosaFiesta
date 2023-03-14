namespace Contracts.Model.Product.Response;

public class WarrantyResponse: BaseResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; } 
    public string Type { get; set; } 
    public string ScopeType { get; set; }
    public string? Status { get; set; }
    public string Period { get; set; } = "Period";
    public string Description { get; set; } = "Description";
    public string Conditions { get; set; } = "Conditions";
    public ICollection<ProductsResponse>? Products { get; set; }
}