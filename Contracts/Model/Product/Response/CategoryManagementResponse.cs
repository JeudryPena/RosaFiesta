﻿namespace Contracts.Model.Product.Response;
public class CategoryManagementResponse : ByBaseResponse
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Icon { get; set; }
	public string? Description { get; set; }
	public ICollection<SubCategoryManagementResponse>? SubCategories { get; set; }
}
