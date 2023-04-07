namespace Domain.Entities.Product;

public class ProductsDiscountsEntity
{
    public Guid Id { get; set; }
    public string DiscountCode { get; set; }
    public string? ProductId { get; set; }
    public int? OptionId { get; set; }
    public OptionEntity? Option { get; set; }
}