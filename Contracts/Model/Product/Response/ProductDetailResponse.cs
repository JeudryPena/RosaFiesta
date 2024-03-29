﻿namespace Contracts.Model.Product.Response;

public class ProductDetailResponse : BaseResponse
{
	public Guid Id { get; set; }
	public int? CategoryId { get; set; }
	public Guid? OptionId { get; set; }
	public bool IsService { get; set; }
	public WarrantyPreviewResponse Warranty { get; set; }
	public OptionDetailResponse Option { get; set; }
	public ICollection<OptionPreviewResponse> Options { get; set; }
}