using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Product.UserInteract;

public class ReviewEntity : BaseEntity, IAutoUpdate
{
	public int Id { get; set; }
	[StringLength(250, MinimumLength = 3)]
	public string? Description { get; set; }
	[Range(0, 5)]
	public float Rating { get; set; }
	[StringLength(50, MinimumLength = 3)]
	public string? Title { get; set; }
	public string UserId { get; set; }
	public Guid OptionId { get; set; }
}