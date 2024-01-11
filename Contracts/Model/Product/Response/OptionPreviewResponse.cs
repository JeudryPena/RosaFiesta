namespace Contracts.Model.Product.Response;

public class OptionPreviewResponse : BaseResponse
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public double Price { get; set; }
	public MultipleImagesResponse Image { get; set; }
	public string Condition { get; set; }
	public float? AverageRating => Reviews == null || Reviews.Count == 0 ? null : Reviews.Average(r => r.Rating);
	public int? TotalReviews => Reviews == null || Reviews.Count == 0 ? null : Reviews.Count;
	public ICollection<ReviewPreviewResponse>? Reviews { get; set; }
	public string Color { get; set; }
	public string GenderFor { get; set; }
	public ICollection<ProductsDiscountPreviewResponse>? ProductsDiscount { get; set; }
	public Guid ProductId { get; set; }
}