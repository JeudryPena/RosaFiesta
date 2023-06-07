using Contracts.Model.Product.UserInteract.Response;

namespace Contracts.Model.Product.Response;

public class ProductResponse
{
	public string? Code { get; set; }
	public string Title { get; set; } = string.Empty;
	public string? Brand { get; set; }
	public string Type { get; set; }
	public int? CategoryId { get; set; }
	public Guid? WarrantyId { get; set; }
	public Guid? SupplierId { get; set; }
	public int OptionId { get; set; }
	public DateTimeOffset? LastDate => Reviews == null || Reviews.Count == 0 ? null : Reviews.Max(r => r.CreatedAt);
	public float? AverageRating => Reviews == null || Reviews.Count == 0 ? null : Reviews.Average(r => r.Rating);
	public int? TotalReviews => Reviews == null || Reviews.Count == 0 ? null : Reviews.Count;
	public ICollection<ReviewResponse>? Reviews { get; set; }
	public int TotalOptions => Options.Count;
	public ICollection<OptionPreviewResponse> Options { get; set; }


}