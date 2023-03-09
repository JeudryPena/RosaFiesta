﻿namespace Contracts.Model.Product.Response;

public class SupplierResponse: BaseResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } 
    public string? Email { get; set; } 
    public string? Phone { get; set; } 
    public string Address { get; set; } 
    public ICollection<ProductsResponse>? ProductsSupplied { get; set; }
}