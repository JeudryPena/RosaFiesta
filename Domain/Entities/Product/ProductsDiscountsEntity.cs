namespace Domain.Entities.Product;

public class ProductsDiscountsEntity : ISoftDelete
{
	public Guid Id { get; set; }
	public Guid DiscountId { get; set; }
	public int OptionId { get; set; }
	public OptionEntity Option { get; set; }
	public bool IsDeleted { get; set; }
}