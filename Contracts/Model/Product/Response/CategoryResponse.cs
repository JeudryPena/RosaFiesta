﻿namespace Contracts.Model.Product.Response;

public class CategoryResponse: BaseResponse
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public string Description { get; set; }    
    public string Image { get; set; } 
    public string Icon { get; set; } 
    public string Slug { get; set; }
    public bool IsActive { get; set; }
    public ICollection<SubCategoryResponse>? SubCategories { get; set; } 
    public ICollection<ProductsResponse>? Products { get; set; }
}