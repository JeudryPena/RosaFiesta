using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Product;

public class ProductsDiscountsEntity : ISoftDelete
{
	public Guid Id { get; set; }
	[StringLength(25, MinimumLength = 5)]
	public string Code { get; set; }
	public int OptionId { get; set; }
	public OptionEntity Option { get; set; }
	public bool IsDeleted { get; set; }
}