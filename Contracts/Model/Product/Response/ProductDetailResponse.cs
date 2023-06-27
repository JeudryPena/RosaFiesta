namespace Contracts.Model.Product.Response;

public class ProductDetailResponse : BaseResponse
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public string? Brand { get; set; }
	public int? CategoryId { get; set; }
	public int? OptionId { get; set; }
	public Guid WarrantyId { get; set; }
	public string? WarrantyName { get; set; }
	public OptionDetailResponse Option { get; set; }
	public ICollection<OptionPreviewResponse> Options { get; set; }
}